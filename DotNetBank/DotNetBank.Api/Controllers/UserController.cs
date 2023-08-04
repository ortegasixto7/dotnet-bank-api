using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetBank.Core.User.SignIn;
using DotNetBank.Core.Validation;
using DotNetBank.External.Auth;

namespace DotNetBank.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAuthPersistence authPersistence;
        public UserController(IAuthPersistence authPersistence)
        {
            this.authPersistence = authPersistence;
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            return await new EndpointService().ResponseWrapper(() => new SignInUseCase(authPersistence).Execute(request));
        }

        [HttpPost("sign-up/v1")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignInRequest request)
        {
            return await new EndpointService().ResponseWrapper(() => new SignInUseCase(authPersistence).Execute(request));
        }
    }
}
