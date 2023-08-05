
namespace DotNetBank.Api.Core.Validation
{
    public class NotFoundException : Exception
    {
        public NotFoundException(CustomException code) : base(Enum.GetName(code)) { }
    }
}
