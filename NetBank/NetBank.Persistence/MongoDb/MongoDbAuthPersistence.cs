using MongoDB.Driver;
using NetBank.External.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Persistence.MongoDb
{
    public class MongoDbAuthPersistence : IAuthPersistence
    {
        private readonly IMongoCollection<Auth> collection;

        public MongoDbAuthPersistence()
        {
            var mongoDatabase = MongoDbClient.GetInstance();
            collection = mongoDatabase.GetCollection<Auth>("auth");
        }

        public async Task CreateAsync(Auth data)
        {
            await collection.InsertOneAsync(data);
        }

        public async Task<Auth?> GetByUserNameOrNullAsync(string userName)
        {
            return await collection.Find(x => x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Auth data)
        {
            await collection.ReplaceOneAsync(data.Id, data);
        }
    }
}
