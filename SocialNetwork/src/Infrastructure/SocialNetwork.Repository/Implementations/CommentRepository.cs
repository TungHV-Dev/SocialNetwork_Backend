using Dapper;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Common.Requests;
using SocialNetwork.Data.Dtos.Comment;
using SocialNetwork.Data.Responses.Comment;
using SocialNetwork.Repository.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        #region Fields
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Contructor
        public CommentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        #endregion

        #region Public Functions
        public async Task<CreateCommentResponse> CreateComment(CreateCommentRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.POST_ID, request.PostID, DbType.Guid);
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);
            parameters.Add(SqlParameters.CONTENT, request.Content, DbType.String);
            parameters.Add(SqlParameters.ACTION_STATUS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.Comment.CREATE_COMMENT;
            var data = await _dbConnection.QueryFirstAsync<CreateCommentResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var actionStatus = parameters.Get<int>(SqlParameters.ACTION_STATUS);

            return actionStatus switch
            {
                0 => data,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_POST_ID),
                -2 => throw new BadRequestException(ErrorMessages.INVALID_USER_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<bool> DeleteComment(Guid commentID)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.COMMENT_ID, commentID, DbType.Guid);

            var procedureName = ProcedureNames.Comment.DELETE_COMMENT;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_COMMENT_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<bool> EditComment(EditCommentRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.COMMENT_ID, request.CommentID, DbType.Guid);
            parameters.Add(SqlParameters.CONTENT, request.Content, DbType.String);

            var procedureName = ProcedureNames.Comment.EDIT_COMMENT;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_COMMENT_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<GetAllCommentResponse> GetAllComment(GetAllCommentRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.POST_ID, request.PostID, DbType.Guid);
            parameters.Add(SqlParameters.CURRENT_PAGE, request.PagingRequest.CurrentPage, DbType.Int32);
            parameters.Add(SqlParameters.PAGE_SIZE, request.PagingRequest.PageSize, DbType.Int32);
            parameters.Add(SqlParameters.SEARCH, PagingRequest.CleanSearchString(request.PagingRequest.Search), DbType.String);
            parameters.Add(SqlParameters.SORT, SortRequest.BuildSortString(request.PagingRequest.Sorts), DbType.String);
            parameters.Add(SqlParameters.TOTAL_ITEMS, DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add(SqlParameters.ACTION_STATUS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.Comment.GET_ALL_COMMENT;
            var data = await _dbConnection.QueryAsync<GetCommentResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var totalItems = parameters.Get<int>(SqlParameters.TOTAL_ITEMS);
            var actionStatus = parameters.Get<int>(SqlParameters.ACTION_STATUS);

            return actionStatus switch
            {
                0 => new GetAllCommentResponse
                {
                    CurrentPage = request.PagingRequest.CurrentPage,
                    PageSize = request.PagingRequest.PageSize,
                    TotalItems = totalItems,
                    Data = data
                },
                -1 => throw new BadRequestException(ErrorMessages.INVALID_POST_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }
        #endregion
    }
}
