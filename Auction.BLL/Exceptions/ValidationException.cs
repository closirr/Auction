using System;

namespace Auction.BLL.Exceptions
{
    class ValidationException:Exception
    {
        protected  string Property { get; }
        public ValidationException(string message, string _prop) : base(message)
        {
            Property = _prop;
        }
    }
}
