using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBank.Core.Currency;
using NetBank.Core.Currency.UseCases.Create;
using NetBank.Core.Validation;

namespace NetBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyPersistence currencyPersistence;

        public CurrenciesController(ICurrencyPersistence currencyPersistence)
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
