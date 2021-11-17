using System.Data;

namespace SocialNetwork.Infrastructure.DatabaseFactory
{
    public interface IDbFactory
    {
        IDbConnection CreateConnection();
    }
}
