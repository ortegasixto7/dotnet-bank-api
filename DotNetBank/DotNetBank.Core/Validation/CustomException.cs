
namespace DotNetBank.Core.Validation
{
    public enum CustomException
    {
        // Required
        CODE_IS_REQUIRED,
        SYMBOL_IS_REQUIRED,
        FIRST_NAME_IS_REQUIRED,
        LAST_NAME_IS_REQUIRED,
        USER_NAME_IS_REQUIRED,
        PASSWORD_IS_REQUIRED,

        // Exception
        CURRENCY_CODE_ALREADY_EXIST,
        UNAVAILABLE_USERNAME,
        INVALID_LOGIN,

        // Not Found
        CURRENCY_NOT_FOUND,

    }
}
