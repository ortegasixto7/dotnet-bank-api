﻿
namespace DotNetBank.Core.Validation
{
    public class BadRequestException : Exception
    {
        public BadRequestException(CustomException code) : base(Enum.GetName(code)) { }
    }
}
