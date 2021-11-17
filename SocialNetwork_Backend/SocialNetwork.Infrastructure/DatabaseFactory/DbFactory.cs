using SocialNetwork.Common.Configurations;
using System.Data;
using System.Data.SqlClient;

namespace SocialNetwork.Infrastructure.DatabaseFactory
{
    public class DbFactory : IDbFactory
    {
        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(AppSetting.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
