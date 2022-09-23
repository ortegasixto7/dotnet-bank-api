using MongoDB.Driver;
using NetBank.Core.Currency;
using NetBank.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Persistence.MongoDb.Currency
{
    public class MongoDbCurrencyPersistence : ICurrencyPersistence
    {
        private readonly IMongoCollection<Core.Currency.Currency> collection;

        public MongoDbCurrencyPersistence()
        {
            var mongoClient = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_CONNECTION_URL"));
            var mongoDatabase = mongoClient.GetDatabase(Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME"));
            collection = mongoDatabase.GetCollection<Core.Currency.Currency>("currencies");
        }

        public async Task CreateAsync(Core.Currency.Currency data)
        {
            await collection.InsertOneAsync(data);
        }

        public async Task<Core.Currency.Currency> GetActiveByCodeOrExceptionAsync(string code)
        {
            var result = await collection.Find(x => x.IsActive == true).FirstOrDefaultAsync();
            if (result == null) throw new Exception(CustomException.CurrencyNotFound);
            return result;
        }

        public async Task<IEnumerable<Core.Currency.Currency>> GetAllActiveAsync()
        {
            return await collection.Find(x => x.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<Core.Currency.Currency>> GetAllInactiveAsync()
        {
            return await collection.Find(x => x.IsActive == false).ToListAsync();
        }

        public async Task<Core.Currency.Currency> GetByCodeOrExceptionAsync(string code)
        {
            var result = await collection.Find(x => x.Code == code).FirstOrDefaultAsync();
            if (result == null) throw new Exception(CustomException.CurrencyNotFound);
            return result;
        }

        public async Task<Core.Currency.Currency?> GetByCodeOrNullAsync(string code)
        {
            return await collection.Find(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Core.Currency.Currency data)
        {
            await collection.ReplaceOneAsync(data.Id, data);
        }
    }
}
