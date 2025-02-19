using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barberia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser()
        {
            return null;
        }
    }
}
