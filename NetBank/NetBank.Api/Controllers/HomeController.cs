using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBank.Core.Currency;

namespace NetBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICurrencyPersistence currencyPersistence;

        public HomeController(ICurrencyPersistence _currencyPersistence)
        {
            currencyPersistence = _currencyPersistence;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var test = Environment.GetEnvironmentVariable("TEST");
            return Ok(new { Test = test, Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds() });
        }
    }
}
