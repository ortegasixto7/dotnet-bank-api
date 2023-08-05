
namespace DotNetBank.Api.Core.Currency
{
    public interface ICurrencyPersistence
    {
        Task CreateAsync(Currency data);
        Task UpdateAsync(Currency data);
        Task<Currency?> GetByCodeOrNullAsync(string code);
        Task<Currency> GetByCodeOrExceptionAsync(string code);
        Task<Currency> GetActiveByCodeOrExceptionAsync(string code);
        Task<IEnumerable<Currency>> GetAllActiveAsync();
        Task<IEnumerable<Currency>> GetAllInactiveAsync();
    }
}
