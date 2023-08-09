using Microsoft.AspNetCore.Mvc;
using DotNetBank.Api.Core.Admin.UseCases.Create;
using DotNetBank.Api.External.Auth;

namespace DotNetBank.Api.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAuthPersistence authPersistence;
        public AdminController(IAuthPersistence authPersistence)
        {
            this.authPersistence = authPersistence; 
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await new CreateUseCase(authPersistence).Execute();
            return Ok();
        }
    }
}
