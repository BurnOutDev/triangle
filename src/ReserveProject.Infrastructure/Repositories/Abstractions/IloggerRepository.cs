using ReserveProject.Shared.Log;

namespace ReserveProject.Infrastructure.Repositories.Abstractions
{
    public interface ILoggerRepository
    {
        long LogException(ExceptionLog exceptionLog);
    }
}
