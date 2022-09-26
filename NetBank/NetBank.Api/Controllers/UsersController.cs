using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBank.Core.User.SignIn;
using NetBank.Core.Validation;
using NetBank.External.Auth;

namespace NetBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthPersistence authPersistence;
        public UsersController(IAuthPersistence authPersistence)
        {
            this.authPersistence = authPersistence;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            try
            {
                var token = await new SignInUseCase(authPersistence).Execute(request);
                return Ok(new { token });
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
