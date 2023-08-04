using DotNetBank.Core.Validation;
using DotNetBank.External.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Core.Admin.UseCases.Create
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
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                Role = AuthRoles.Admin
            };
            var existUser = await authPersistence.GetByUserNameOrNullAsync(user.UserName);
            if (existUser != null) throw new BadRequestException(CustomExceptionCodes.UnavailableUsername);
            await authPersistence.CreateAsync(user);
        }
    }
}
