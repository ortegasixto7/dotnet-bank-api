using DotNetBank.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBank.Core.Currency.UseCases.Create
{
    public class CreateRequestValidation : IRequestValidator<CreateRequest>
    {
        public void Validate(CreateRequest request)
        {
            if (string.IsNullOrEmpty(request.Code)) throw new BadRequestException(CustomExceptionCodes.CodeIsRequired);
            if (string.IsNullOrEmpty(request.Symbol)) throw new BadRequestException(CustomExceptionCodes.SymbolIsRequired);
        }
    }
}
