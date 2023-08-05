
namespace DotNetBank.Api.External.Auth
{
    public class Auth
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public long CreatedAt { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        public List<int> Roles { get; set; } = new List<int>() { (int)AuthRole.USER };
    }

    public enum AuthRole
    {
        ADMIN,
        USER
    }
}
