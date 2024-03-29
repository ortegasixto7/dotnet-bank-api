﻿
namespace DotNetBank.Api.Core.User
{
    public interface IUserPersistence
    {
        Task CreateAsync(User data);
        Task<User?> GetByUserNameOrNullAsync(string userName);
    }
}
