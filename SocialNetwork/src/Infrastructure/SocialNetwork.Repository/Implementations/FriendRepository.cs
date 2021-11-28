using Dapper;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Data.Dtos.Friend;
using SocialNetwork.Data.Responses.Friend;
using SocialNetwork.Repository.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Implementations
{
    public class FriendRepository : IFriendRepository
    {
        #region Fields
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Contructor
        public FriendRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        #endregion

        #region Public Functions
        public async Task<SendFriendRequestResponse> SendFriendRequest(SendFriendRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.SENDER_ID, request.SenderID, DbType.Guid);
            parameters.Add(SqlParameters.RECEIVER_ID, request.ReceiverID, DbType.Guid);
            parameters.Add(SqlParameters.FRIEND_REQUEST_STATUS, request.RequestStatus, DbType.Int16);
            parameters.Add(SqlParameters.ACTION_STATUS, DbType.Int16, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.Friend.SEND_FRIEND_REQUEST;
            var response = await _dbConnection.QueryFirstAsync<SendFriendRequestResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var actionStatus = parameters.Get<int>(SqlParameters.ACTION_STATUS);

            return actionStatus switch
            {
                0 => response,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_RECEIVER_ID),
                -2 => throw new ConflictException(ErrorMessages.IS_PENDING_OR_HAVE_BEEN_FRIENDS),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<bool> CancelFriendRequest(Guid requestID)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.REQUEST_ID, requestID, DbType.Guid);

            var procedureName = ProcedureNames.Friend.CANCEL_FRIEND_REQUEST;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_REQUEST_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }
        
        public async Task<bool> ActionForFriendRequest(ActionForFriendRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.REQUEST_ID, request.RequestID, DbType.Guid);
            parameters.Add(SqlParameters.FRIEND_REQUEST_ACTION, request.Action, DbType.Int16);

            var procedureName = ProcedureNames.Friend.ACTION_FOR_FRIEND_REQUEST;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_REQUEST_ID),
                -2 => throw new BadRequestException(ErrorMessages.REQUEST_IS_ACCEPTED_OR_REJECTED),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<bool> Unfriend(UnfriendRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_ID, request.UserID, DbType.Guid);
            parameters.Add(SqlParameters.FRIEND_ID, request.FriendID, DbType.Guid);

            var procedureName = ProcedureNames.Friend.UNFRIEND_WITH_ANOTHER_USER;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_FRIEND_ID),
                -2 => throw new ConflictException(ErrorMessages.NOT_FRIENDS),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<GetAllPendingFriendRequestResponse> GetAllPendingFriendRequest(Guid userID)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_ID, userID, DbType.Guid);
            parameters.Add(SqlParameters.TOTAL_ITEMS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.Friend.GET_ALL_PENDING_FRIEND_REQUEST;
            var allRequest = await _dbConnection.QueryAsync<GetPendingFriendRequestResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var totalItems = parameters.Get<int>(SqlParameters.TOTAL_ITEMS);

            return new GetAllPendingFriendRequestResponse
            {
                TotalRequests = totalItems,
                RequestsDetail = allRequest
            };
        }
        #endregion
    }
}
