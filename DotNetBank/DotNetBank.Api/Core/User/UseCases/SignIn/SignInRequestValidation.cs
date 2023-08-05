using DotNetBank.Api.Core.Validation;

namespace DotNetBank.Api.Core.User.UseCases.SignIn
{
    public class SignInRequestValidation : IRequestValidator<SignInRequest>
    {
        public void Validate(SignInRequest request)
        {
            if (string.IsNullOrEmpty(request.Username)) throw new BadRequestException(CustomException.USER_NAME_IS_REQUIRED);
            if (string.IsNullOrEmpty(request.Password)) throw new BadRequestException(CustomException.PASSWORD_IS_REQUIRED);
        }
    }
}
