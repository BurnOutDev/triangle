using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using ReserveProject.Infrastructure.Repositories.Abstractions;
using ReserveProject.Shared.Log;
using System.Data;
using System.Data.SqlClient;

namespace ReserveProject.Infrastructure.Repositories
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly IConfiguration _configuration;

        public LoggerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public long LogException(ExceptionLog exceptionLog)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("OptimusDbContext")))
            {

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                return connection.Insert(exceptionLog);
            }
        }
    }
}
