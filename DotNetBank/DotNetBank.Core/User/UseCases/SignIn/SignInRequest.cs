
namespace DotNetBank.Core.User.UseCases.SignIn
{
    public class SignInRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
