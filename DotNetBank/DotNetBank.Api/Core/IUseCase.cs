
namespace DotNetBank.Api.Core
{
    public interface IUseCaseCommand<T>
    {
        Task Execute(T request);
    }

    public interface IUseCaseQuery<T>
    {
        Task<dynamic> Execute(T request);
    }
}
