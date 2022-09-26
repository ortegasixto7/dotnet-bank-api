using NetBank.Core.Validation;
using NetBank.External.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Core.User.SignIn
{
    public class SignInUseCase : IUseCaseQuery<SignInRequest>
    {
        private readonly IAuthPersistence authPersistence;
        public SignInUseCase(IAuthPersistence authPersistence)
        {
            this.authPersistence = authPersistence;
        }

        public async Task<dynamic> Execute(SignInRequest request)
        {
            new SignInRequestValidation().Validate(request);
            var auth = await authPersistence.GetByUserNameOrNullAsync(request.Username);
            if(auth == null) throw new BadRequestException(CustomExceptionCodes.InvalidLogin);
            if(!BCrypt.Net.BCrypt.Verify(request.Password, auth.Password)) throw new BadRequestException(CustomExceptionCodes.InvalidLogin);
            var token = "THE_TOKEN_RESULT";
            return token;
        }
    }
}
