using DotNetBank.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Core.User.SignIn
{
    public class SignInRequestValidation : IRequestValidator<SignInRequest>
    {
        public void Validate(SignInRequest request)
        {
            if (string.IsNullOrEmpty(request.Username)) throw new BadRequestException(CustomExceptionCodes.UsernameIsRequired);
            if (string.IsNullOrEmpty(request.Password)) throw new BadRequestException(CustomExceptionCodes.PasswordIsRequired);
        }
    }
}
