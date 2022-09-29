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
            return await new EndpointService().ResponseWrapper(() => new SignInUseCase(authPersistence).Execute(request));
        }
    }
}
