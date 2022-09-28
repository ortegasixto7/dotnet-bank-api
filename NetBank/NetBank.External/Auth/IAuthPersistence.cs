using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.External.Auth
{
    public interface IAuthPersistence
    {
        Task CreateAsync(Auth data);
        Task UpdateAsync(Auth data);
        Task<Auth?> GetByUserNameOrNullAsync(string userName);
    }
}
