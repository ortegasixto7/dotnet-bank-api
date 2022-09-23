using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Core.Validation
{
    public abstract class CustomException
    {
        public static readonly string CurrencyNotFound = "CURRENCY_NOT_FOUND";
    }
}
