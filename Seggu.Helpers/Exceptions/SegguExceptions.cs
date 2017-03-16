using System;

namespace Seggu.Helpers.Exceptions
{
    public class ParseLoginException : Exception
    {
        public ParseLoginException()
        {
        }

        public ParseLoginException(string message)
            : base(message)
        {
        }

        public ParseLoginException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
