using Microsoft.AspNetCore.Mvc;
using DotNetBank.Api.Core.Currency;
using DotNetBank.Api.Core.Currency.UseCases.Create;
using DotNetBank.Api.Core.Validation;

namespace DotNetBank.Api.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyPersistence currencyPersistence;

        public CurrencyController(ICurrencyPersistence currencyPersistence)
        {
            this.currencyPersistence = currencyPersistence;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateRequest request)
        {
            try
            {
                await new CreateUseCase(currencyPersistence).Execute(request);
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
