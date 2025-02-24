using Barberia.Application.Repositories.IRepositories;
using Barberia.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barberia.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAllUser")]
        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await _unitOfWork.userRepository.GetAllAsync();
        }
    }
}
