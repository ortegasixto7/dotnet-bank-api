using DotNetBank.Api.Core.Validation;

namespace DotNetBank.Api.Core.User.UseCases.SignUp
{
    public class SignUpRequestValidation : IRequestValidator<SignUpRequest>
    {
        public void Validate(SignUpRequest request)
        {
            if (string.IsNullOrEmpty(request.FirstName)) throw new BadRequestException(CustomException.FIRST_NAME_IS_REQUIRED);
            if (string.IsNullOrEmpty(request.LastName)) throw new BadRequestException(CustomException.LAST_NAME_IS_REQUIRED);
            if (string.IsNullOrEmpty(request.UserName)) throw new BadRequestException(CustomException.USER_NAME_IS_REQUIRED);
            if (string.IsNullOrEmpty(request.Password)) throw new BadRequestException(CustomException.PASSWORD_IS_REQUIRED);
        }
    }
}
