using MongoDB.Driver;
using NetBank.Core.Currency;
using NetBank.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Persistence.MongoDb
{
    public class MongoDbCurrencyPersistence : ICurrencyPersistence
    {
        private readonly IMongoCollection<Currency> collection;

        public MongoDbCurrencyPersistence()
        {
            var mongoDatabase = MongoDbClient.GetInstance();
            collection = mongoDatabase.GetCollection<Currency>("currencies");
        }

        public async Task CreateAsync(Currency data)
        {
            await collection.InsertOneAsync(data);
        }

        public async Task<Currency> GetActiveByCodeOrExceptionAsync(string code)
        {
            var result = await collection.Find(x => x.IsActive == true).FirstOrDefaultAsync();
            if (result == null) throw new Exception(CustomExceptionCodes.CurrencyNotFound);
            return result;
        }

        public async Task<IEnumerable<Currency>> GetAllActiveAsync()
        {
            return await collection.Find(x => x.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<Currency>> GetAllInactiveAsync()
        {
            return await collection.Find(x => x.IsActive == false).ToListAsync();
        }

        public async Task<Currency> GetByCodeOrExceptionAsync(string code)
        {
            var result = await collection.Find(x => x.Code == code).FirstOrDefaultAsync();
            if (result == null) throw new Exception(CustomExceptionCodes.CurrencyNotFound);
            return result;
        }

        public async Task<Currency?> GetByCodeOrNullAsync(string code)
        {
            return await collection.Find(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Currency data)
        {
            await collection.ReplaceOneAsync(data.Id, data);
        }
    }
}
