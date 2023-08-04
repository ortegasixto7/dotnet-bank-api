using DotNetBank.Core.User;
using MongoDB.Driver;

namespace DotNetBank.Persistence.MongoDb
{
    public class MongoDbUserPersistence : IUserPersistence
    {
        private readonly IMongoCollection<User> collection;
        public MongoDbUserPersistence() 
        {
            var mongoDatabase = MongoDbClient.GetInstance();
            collection = mongoDatabase.GetCollection<User>("users");
        }

        public async Task CreateAsync(User data)
        {
            await collection.InsertOneAsync(data);
        }

        public async Task<User?> GetByUserNameOrNullAsync(string userName)
        {
            return await collection.Find(x => x.UserName == userName).FirstOrDefaultAsync();
        }
    }
}
