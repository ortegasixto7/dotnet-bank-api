
namespace DotNetBank.Core.User.UseCases.SignUp
{
    public class SignUpUseCase : IUseCaseCommand<SignUpRequest>
    {
        private readonly IUserPersistence userPersistence;

        public SignUpUseCase(IUserPersistence userPersistence) 
        { 
            this.userPersistence = userPersistence;
        }

        public async Task Execute(SignUpRequest request)
        {
            new SignUpRequestValidation().Validate(request);
            User user = new()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };
            await userPersistence.CreateAsync(user);
        }
    }
}
