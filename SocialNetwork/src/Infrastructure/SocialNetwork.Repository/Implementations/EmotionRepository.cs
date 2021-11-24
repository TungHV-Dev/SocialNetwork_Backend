using Dapper;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Data.Dtos.Emotion;
using SocialNetwork.Data.Responses.Emotion;
using SocialNetwork.Repository.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Implementations
{
    public class EmotionRepository : IEmotionRepository
    {
        #region Fields
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Contructor
        public EmotionRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        #endregion

        #region
        public async Task<bool> ExpressEmotionToPost(ExpressEmotionRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);
            parameters.Add(SqlParameters.POST_ID, request.PostID, DbType.Guid);
            parameters.Add(SqlParameters.STATUS, request.Status, DbType.Int16);

            var procedureName = ProcedureNames.Emotion.EXPRESS_EMOTION;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_USER_ID),
                -2 => throw new BadRequestException(ErrorMessages.INVALID_POST_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<GetAllEmotionResponse> GetAllEmotionOfPost(GetAllEmotionRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);
            parameters.Add(SqlParameters.POST_ID, request.PostID, DbType.Guid);
            parameters.Add(SqlParameters.TOTAL_ITEMS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.Emotion.GET_ALL_EMOTIONS;
            var data = await _dbConnection.QueryAsync<GetEmotionResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var totalItems = parameters.Get<int>(SqlParameters.TOTAL_ITEMS);

            return new GetAllEmotionResponse
            {
                TotalItems = totalItems,
                Data = data
            };
        }

        public async Task<GetAllUserResponse> GetEmotionUserOfPost(GetEmotionUserRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);
            parameters.Add(SqlParameters.POST_ID, request.PostID, DbType.Guid);
            parameters.Add(SqlParameters.STATUS, request.Status, DbType.Int16);
            parameters.Add(SqlParameters.TOTAL_ITEMS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.Emotion.GET_EMOTION_USER;
            var data = await _dbConnection.QueryAsync<UserResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var totalItems = parameters.Get<int>(SqlParameters.TOTAL_ITEMS);

            return new GetAllUserResponse
            {
                TotalItems = totalItems,
                Data = data
            };
        }
        #endregion
    }
}
