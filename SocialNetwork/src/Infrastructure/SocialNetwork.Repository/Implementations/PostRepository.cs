using Dapper;
using Newtonsoft.Json;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Data.Responses.Post;
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

        #region Public Functions
        public async Task<CreatePostResponse> CreatePost(CreatePostRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.CONTENT, request.Content, DbType.String);
            parameters.Add(SqlParameters.FEELING_STATUS, request.FeelingStatus, DbType.Int16);
            parameters.Add(SqlParameters.PRIVACY_STATUS, request.PrivacyStatus, DbType.Int16);
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);
            parameters.Add(SqlParameters.ACTION_STATUS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.Post.CREATE_POST;
            var response = await _dbConnection.QueryFirstAsync<CreatePostResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var actionStatus = parameters.Get<int>(SqlParameters.ACTION_STATUS);

            return actionStatus switch
            {
                0 => response,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_USER_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<bool> DeletePost(DeletePostRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.POST_ID, request.PostID, DbType.Guid);
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);

            var procedureName = ProcedureNames.Post.DELETE_POST;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_USER_ID),
                -2 => throw new BadRequestException(ErrorMessages.INVALID_POST_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<bool> EditPost(EditPostRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);
            parameters.Add(SqlParameters.POST_ID, request.PostID, DbType.Guid);
            parameters.Add(SqlParameters.CONTENT, request.Content, DbType.String);
            parameters.Add(SqlParameters.FEELING_STATUS, request.FeelingStatus, DbType.Int16);
            parameters.Add(SqlParameters.PRIVACY_STATUS, request.PrivacyStatus, DbType.Int16);

            var procedureName = ProcedureNames.Post.EDIT_POST;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_USER_ID),
                -2 => throw new BadRequestException(ErrorMessages.INVALID_POST_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<GetAllPostsInTimelineResponse> GetAllPostsInTimeline(GetAllPostsInTimelineRequestDto request)
        {
            var jsonData = JsonConvert.SerializeObject(request.FriendIds);
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.JSON_DATA, jsonData, DbType.String);
            parameters.Add(SqlParameters.CURRENT_PAGE, request.Request.CurrentPage, DbType.Int32);
            parameters.Add(SqlParameters.PAGE_SIZE, request.Request.PageSize, DbType.Int32);
            parameters.Add(SqlParameters.TOTAL_ITEMS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.Post.GET_ALL_POSTS_IN_TIMELINE;
            var data = await _dbConnection.QueryAsync<GetPostInTimelineResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var totalItems = parameters.Get<int>(SqlParameters.TOTAL_ITEMS);

            return new GetAllPostsInTimelineResponse
            {
                CurrentPage = request.Request.CurrentPage,
                PageSize = request.Request.PageSize,
                TotalItems = totalItems,
                Data = data
            };
        }

        public async Task<GetAllPostsOfUserResponse> GetAllPostsOfUser(GetAllPostsOfUserRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);
            parameters.Add(SqlParameters.CURRENT_PAGE, request.PagingRequest.CurrentPage, DbType.Int32);
            parameters.Add(SqlParameters.PAGE_SIZE, request.PagingRequest.PageSize, DbType.Int32);
            parameters.Add(SqlParameters.TOTAL_ITEMS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.Post.GET_ALL_POSTS_OF_USER;
            var data = await _dbConnection.QueryAsync<GetPostsOfUserResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var totalItems = parameters.Get<int>(SqlParameters.TOTAL_ITEMS);

            return new GetAllPostsOfUserResponse
            {
                CurrentPage = request.PagingRequest.CurrentPage,
                PageSize = request.PagingRequest.PageSize,
                TotalItems = totalItems,
                Data = data
            };

        }
        #endregion
    }
}
