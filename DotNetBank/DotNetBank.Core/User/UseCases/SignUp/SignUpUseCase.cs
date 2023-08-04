
using DotNetBank.Core.Validation;
using DotNetBank.External.Auth;

namespace DotNetBank.Core.User.UseCases.SignUp
{
    public class SignUpUseCase : IUseCaseCommand<SignUpRequest>
    {
        private readonly IUserPersistence userPersistence;
        private readonly IAuthPersistence authPersistence;

        public SignUpUseCase(IUserPersistence userPersistence, IAuthPersistence authPersistence) 
        { 
            this.userPersistence = userPersistence;
            this.authPersistence = authPersistence;
        }

        public async Task Execute(SignUpRequest request)
        {
            new SignUpRequestValidation().Validate(request);
            var userExists = await authPersistence.GetByUserNameOrNullAsync(request.UserName);
            if (userExists != null) throw new BadRequestException(CustomException.UNAVAILABLE_USERNAME);

            Auth auth = new()
            {
                UserName = request.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            };

            User user = new()
            {
                Id = auth.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = auth.UserName,
                CreatedAt = auth.CreatedAt
            };

            await Task.WhenAll(userPersistence.CreateAsync(user), authPersistence.CreateAsync(auth));
        }
    }
}
