using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Core.User
{
    interface IUserPersistence
    {
        Task CreateAsync(User user);
        Task<User?> GetByUserNameOrNullAsync(string userName);
    }
}
