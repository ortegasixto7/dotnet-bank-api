
namespace DotNetBank.Api.Core.Currency.UseCases.Create
{
    public class CreateRequest
    {
        public string Code { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
    }
}
