using AutoMapper;
using Barberia.Application.Repositories.IRepositories;
using Barberia.Core.Constants;
using Barberia.Core.DTOs.UserDTO;
using Barberia.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Barberia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        IConfiguration _configuration;

        public AuthController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegistrationDTO request)
        {
            if (ModelState.IsValid && request != null)
            {
                var existUser =  await _unitOfWork.userRepository.GetUserByEmail(request.Email);
                if (existUser == null) 
                {
                    AppUser newUser = new AppUser
                    {
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        PhoneNumber = request.Phone,
                        Password = request.Password,
                        Address = request.Address,
                        UserName = request.FirstName + request.LastName,
                        CreatedAt = DateTime.Now,
                    };
                    var result = await _userManager.CreateAsync(newUser, request.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(newUser, isPersistent: false);
                        await _userManager.AddToRoleAsync(newUser, "User"); 
                    }
                }
                else
                {
                    return BadRequest($"User with {request.Email} eamil is already exist.");
                }
                
                return Ok("User Created Successful.");
            }
            else
            {
                return BadRequest("");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO request)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    return BadRequest("Invalid Credentials.");
                }
                // Set Claims
                var authClaims = new List<Claim>
                                                {
                                                    new Claim("UserId", user.Id),
                                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                                };

                // Generate Token
                var token = GenerateToken(authClaims);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }); 
            }
            else
            {
                return BadRequest("Invalid Credentials.");
            }
        }
        private JwtSecurityToken GenerateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[AppConstants.JWT_Secret]!));

            var token = new JwtSecurityToken(
                issuer: _configuration[AppConstants.JWT_ValidIssuer],
                audience: _configuration[AppConstants.JWT_ValidAudience],
                expires: DateTime.UtcNow.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
