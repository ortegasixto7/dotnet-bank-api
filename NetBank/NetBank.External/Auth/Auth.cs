using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.External.Auth
{
    public class Auth
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public long CreatedAt { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        public string Role { get; set; } = AuthRoles.User;
    }

    public abstract class AuthRoles
    {
        public readonly static string Admin = "ADMIN";
        public readonly static string User = "USER";
    }
}
