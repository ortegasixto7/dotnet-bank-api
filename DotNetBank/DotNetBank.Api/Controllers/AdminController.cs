using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetBank.Core.Admin.UseCases.Create;
using DotNetBank.Core.Validation;
using DotNetBank.External.Auth;

namespace DotNetBank.Api.Controllers
{
    [Route("api/[controller]")]
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
            return await new EndpointService().ResponseWrapper(new CreateUseCase(authPersistence).Execute);
        }
    }
}
