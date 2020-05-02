using Dapper.Contrib.Extensions;

namespace ReserveProject.Infrastructure.Database.Configurations.Dapper
{
    public static class DapperNamingMapperExtensions
    {
        public static void DefineDapperNameMapping()
        {
            SqlMapperExtensions.TableNameMapper = (type) =>
            {
                switch (type.Name)
                {
                    case "ExceptionLog":
                        return "[Shared].[ExceptionLogs]";
                    default:
                        return type.Name;
                }
            };
        }
    }
}
