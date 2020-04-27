using System;

namespace ReserveProject.Shared.Exceptions
{
    public class ApplicationExcepiton : Exception
    {
        public ApplicationExcepiton(string message) : base(message)
        {
        }

        public ApplicationExcepiton(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; }
    }
}
