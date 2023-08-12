using DotNetBank.Api.Core.User;
using DotNetBank.Api.Core.User.UseCases.SignUp;
using DotNetBank.Api.External.Auth;

namespace DotNetBank.Api.GraphQL
{
    public class Mutation
    {
        private readonly IAuthPersistence authPersistence;
        private readonly IUserPersistence userPersistence;
        public Mutation(IAuthPersistence authPersistence, IUserPersistence userPersistence)
        {
            this.authPersistence = authPersistence;
            this.userPersistence = userPersistence;
        }

        public async Task<bool> SignUpUser(SignUpRequest request)
        {
            await new SignUpUseCase(userPersistence, authPersistence).Execute(request);
            return true;
        }
    }
}
