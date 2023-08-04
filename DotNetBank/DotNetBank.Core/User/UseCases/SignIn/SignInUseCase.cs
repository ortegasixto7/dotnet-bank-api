using Microsoft.IdentityModel.Tokens;
using DotNetBank.Core.Validation;
using DotNetBank.External.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetBank.Core.User.UseCases.SignIn
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
            if (auth == null) throw new BadRequestException(CustomException.INVALID_LOGIN);
            if (!BCrypt.Net.BCrypt.Verify(request.Password, auth.Password)) throw new BadRequestException(CustomException.INVALID_LOGIN);
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            var secretKey = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? "NO_JWT_SECRET_KEY_SET");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, auth.UserName),
                new Claim(JwtRegisteredClaimNames.Email, auth.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, auth.Id)
             }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenResult = tokenHandler.WriteToken(token);
            return new { token = tokenResult };
        }
    }
}
