using System;

namespace IMC.Product.Shared.Errors
{
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException() : base()
        {
        }

        public UnAuthorizedException(string message) : base(message)
        {
        }
    }
}
