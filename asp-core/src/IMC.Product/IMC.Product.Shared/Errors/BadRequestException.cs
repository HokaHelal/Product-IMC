using System;

namespace IMC.Product.Shared.Errors
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }
    }
}
