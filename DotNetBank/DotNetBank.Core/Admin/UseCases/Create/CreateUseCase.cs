using DotNetBank.Core.Validation;
using DotNetBank.External.Auth;

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
                Roles = new List<int> { (int) AuthRole.ADMIN },
            };
            var existUser = await authPersistence.GetByUserNameOrNullAsync(user.UserName);
            if (existUser != null) throw new BadRequestException(CustomException.UNAVAILABLE_USERNAME);
            await authPersistence.CreateAsync(user);
        }
    }
}
