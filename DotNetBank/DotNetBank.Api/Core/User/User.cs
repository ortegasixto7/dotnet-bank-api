
namespace DotNetBank.Api.Core.User
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public long CreatedAt { get; set; } = 0;
    }
}
