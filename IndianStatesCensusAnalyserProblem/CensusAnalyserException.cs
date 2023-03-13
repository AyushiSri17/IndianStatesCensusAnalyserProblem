using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyserProblem
{
    public class CensusAnalyserException : Exception
    {
        public ExceptionType exception;

        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_HEADER,
            NO_SUCH_COUNTRY,
            INCORRECT_DELIMETER
        }
        public CensusAnalyserException(string message, ExceptionType exception) : base(message)
        {
            this.exception = exception;
        }
    }
}
