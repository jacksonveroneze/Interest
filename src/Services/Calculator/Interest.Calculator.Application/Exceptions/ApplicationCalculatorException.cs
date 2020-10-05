using System;

namespace Interest.Calculator.Application.Exceptions
{
    public class ApplicationCalculatorException : Exception
    {
        public ApplicationCalculatorException()
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
