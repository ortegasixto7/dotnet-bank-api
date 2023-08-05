
namespace DotNetBank.Api.Core.Validation
{
    public interface IRequestValidator<T>
    {
        void Validate(T request);
    }
}
