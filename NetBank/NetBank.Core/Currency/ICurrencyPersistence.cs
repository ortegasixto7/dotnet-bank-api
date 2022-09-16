using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Core.Currency
{
    public interface ICurrencyPersistence
    {
        void Create(Currency data);
        void Update(Currency data);
        Currency? GetByCodeOrNull(string code);
        Currency GetByCodeOrException(string code);
        Currency GetActiveByCodeOrException(string code);
        IEnumerable<Currency> GetAllActive();
        IEnumerable<Currency> GetAllInactive();
    }
}
