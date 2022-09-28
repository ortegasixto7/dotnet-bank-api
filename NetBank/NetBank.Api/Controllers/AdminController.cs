using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBank.Core.Admin.UseCases.Create;
using NetBank.Core.Validation;
using NetBank.External.Auth;

namespace NetBank.Api.Controllers
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
            try
            {
                await new CreateUseCase(authPersistence).Execute();
                return Ok();
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
