using NetBank.Core.Validation;
using NetBank.External.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Core.Admin.UseCases.Create
{
    public class CreateUseCase
    {
        private readonly IAuthPersistence authPersistence;

        public CreateUseCase(IAuthPersistence authPersistence)
        {
            this.authPersistence = authPersistence;
        }
        public async Task Execute()
        {
            var user = new Auth()
            {
                UserName = "admin",
                Password = "123456",
                Role = AuthRoles.Admin
            };
            var existUser = await authPersistence.GetByUserNameOrNullAsync(user.UserName);
            if (existUser != null) throw new BadRequestException(CustomExceptionCodes.UnavailableUserName);
            await authPersistence.CreateAsync(user);
        }
    }
}
