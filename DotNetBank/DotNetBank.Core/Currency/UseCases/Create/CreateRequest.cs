using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Core.Currency.UseCases.Create
{
    public class CreateRequest
    {
        public string Code { get; set; } = "";
        public string Symbol { get; set; } = "";
    }
}
