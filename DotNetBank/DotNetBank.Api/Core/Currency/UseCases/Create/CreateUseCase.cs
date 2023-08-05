using DotNetBank.Api.Core.Validation;

namespace DotNetBank.Api.Core.Currency.UseCases.Create
{
    public class CreateUseCase : IUseCaseCommand<CreateRequest>
    {
        private readonly ICurrencyPersistence currencyPersistence;

        public CreateUseCase(ICurrencyPersistence currencyPersistence)
        {
            this.currencyPersistence = currencyPersistence;
        }

        public async Task Execute(CreateRequest request)
        {
            new CreateRequestValidation().Validate(request);
            var currency = new Currency
            {
                Code = request.Code,
                Symbol = request.Symbol
            };
            var existDuplicatedCode = await currencyPersistence.GetByCodeOrNullAsync(request.Code);
            if (existDuplicatedCode != null) throw new BadRequestException(CustomException.CURRENCY_CODE_ALREADY_EXIST);
            await currencyPersistence.CreateAsync(currency);
        }
    }
}
