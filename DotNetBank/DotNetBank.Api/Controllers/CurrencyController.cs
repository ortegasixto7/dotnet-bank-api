using Microsoft.AspNetCore.Mvc;
using DotNetBank.Api.Core.Currency;
using DotNetBank.Api.Core.Currency.UseCases.Create;

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
            await new CreateUseCase(currencyPersistence).Execute(request);
            return Ok();
        }

    }
}
