using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetBank.Core.User.SignIn;
using DotNetBank.Core.Validation;
using DotNetBank.External.Auth;

namespace DotNetBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IAuthPersistence authPersistence;
        public UsersController(IAuthPersistence authPersistence)
        {
            this.authPersistence = authPersistence;
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            try
            {
                var token = await new SignInUseCase(authPersistence).Execute(request);
                return Ok(new { data = new { token } });
            }
            catch (BadRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(400, new { errorCode = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { errorCode = "INTERNAL_ERROR" });
            }
        }
    }
}
