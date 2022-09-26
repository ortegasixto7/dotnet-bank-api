using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Core.Validation
{
    public abstract class CustomExceptionCodes
    {
        public static readonly string CurrencyNotFound = "CURRENCY_NOT_FOUND";
        public static readonly string CurrencyCodeAlreadyExist = "CURRENCY_CODE_ALREADY_EXIST";
        public static readonly string UnavailableUserName = "UNAVAILABLE_USERNAME";

        public static readonly string CodeIsRequired = "CODE_IS_REQUIRED";
        public static readonly string SymbolIsRequired = "SYMBOL_IS_REQUIRED";
    }
}
