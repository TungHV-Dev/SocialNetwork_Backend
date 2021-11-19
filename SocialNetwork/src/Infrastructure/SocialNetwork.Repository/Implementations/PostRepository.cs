using Dapper;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Repository.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Implementations
{
    public class PostRepository : IPostRepository
    {
        #region Fields
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Contructor
        public PostRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        #endregion

        #region
        public async Task<bool> CreatePost(CreatePostRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.CONTENT, request.Content, DbType.String);
            parameters.Add(SqlParameters.STATUS, request.Status, DbType.Int16);
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);

            var procedureName = ProcedureNames.Post.CREATE_POST;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_USER_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }
        #endregion
    }
}
