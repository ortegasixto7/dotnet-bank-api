
namespace DotNetBank.Api.External.Auth
{
    public interface IAuthPersistence
    {
        Task CreateAsync(Auth data);
        Task UpdateAsync(Auth data);
        Task<Auth?> GetByUserNameOrNullAsync(string userName);
    }
}
