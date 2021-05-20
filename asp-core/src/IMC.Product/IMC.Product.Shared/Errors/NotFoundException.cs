using System;

namespace IMC.Product.Shared.Errors
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
