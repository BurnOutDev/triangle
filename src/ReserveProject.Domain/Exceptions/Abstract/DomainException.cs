using System;

namespace ReserveProject.Domain.Exceptions.Abstract
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; }
    }
}