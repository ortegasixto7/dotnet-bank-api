using Microsoft.IdentityModel.Tokens;
using NetBank.Core.Validation;
using NetBank.External.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
