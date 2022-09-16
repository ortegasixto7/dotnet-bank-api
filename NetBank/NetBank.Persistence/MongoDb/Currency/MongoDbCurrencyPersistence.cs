using NetBank.Core.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Persistence.MongoDb.Currency
{
    public class MongoDbCurrencyPersistence : ICurrencyPersistence
    {
        public void Create(Core.Currency.Currency data)
        {
            throw new NotImplementedException();
        }

        public Core.Currency.Currency GetActiveByCodeOrException(string code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Currency.Currency> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Currency.Currency> GetAllInactive()
        {
            throw new NotImplementedException();
        }

        public Core.Currency.Currency GetByCodeOrException(string code)
        {
            throw new NotImplementedException();
        }

        public Core.Currency.Currency? GetByCodeOrNull(string code)
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Currency.Currency data)
        {
            throw new NotImplementedException();
        }
    }
}
