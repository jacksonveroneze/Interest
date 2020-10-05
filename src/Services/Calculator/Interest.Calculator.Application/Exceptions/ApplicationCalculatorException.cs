using System;

namespace Interest.Calculator.Application.Exceptions
{
    public class ApplicationCalculatorException : Exception
    {
        private ApplicationCalculatorException()
        {
        }

        public ApplicationCalculatorException(string message) : base(message)
        {
        }

        public ApplicationCalculatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
