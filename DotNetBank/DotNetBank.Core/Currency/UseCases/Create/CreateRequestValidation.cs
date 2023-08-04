using DotNetBank.Core.Validation;

namespace DotNetBank.Core.Currency.UseCases.Create
{
    public class CreateRequestValidation : IRequestValidator<CreateRequest>
    {
        public void Validate(CreateRequest request)
        {
            if (string.IsNullOrEmpty(request.Code)) throw new BadRequestException(CustomException.CODE_IS_REQUIRED);
            if (string.IsNullOrEmpty(request.Symbol)) throw new BadRequestException(CustomException.SYMBOL_IS_REQUIRED);
        }
    }
}
