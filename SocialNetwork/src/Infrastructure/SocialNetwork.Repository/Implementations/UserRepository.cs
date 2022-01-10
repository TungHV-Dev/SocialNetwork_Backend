using Dapper;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Data.Dtos.Authentication;
using SocialNetwork.Data.Dtos.User;
using SocialNetwork.Data.Responses.Friend;
using SocialNetwork.Data.Responses.User;
using SocialNetwork.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Contructor
        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        #endregion

        #region Public Functions
        public async Task<FindUserByUserNameResponseDto> FindUserByUserName(string userName)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_NAME, userName, DbType.String);
            parameters.Add(SqlParameters.ACTION_STATUS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.User.FIND_USER_BY_USER_NAME;
            var response = await _dbConnection.QueryFirstAsync<FindUserByUserNameResponseDto>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var actionStatus = parameters.Get<int>(SqlParameters.ACTION_STATUS);
            return actionStatus switch
            {
                0 => response,
                -1 => throw new NotFoundException(ErrorMessages.INVALID_USER_NAME),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<bool> RegisterNewUser(RegisterRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.FIRST_NAME, request.FirstName, DbType.String);
            parameters.Add(SqlParameters.LAST_NAME, request.LastName, DbType.String);
            parameters.Add(SqlParameters.USER_NAME, request.Username, DbType.String);
            parameters.Add(SqlParameters.USER_EMAIL, request.Email, DbType.String);
            parameters.Add(SqlParameters.PASSWORD_HASH, request.PasswordHash, DbType.String);
            parameters.Add(SqlParameters.IS_PUBLIC_ACCOUNT, request.IsPublicAccount, DbType.Boolean);
            parameters.Add(SqlParameters.ROLE, Permission.USER, DbType.String);

            var procedureName = ProcedureNames.User.REGISTER_NEW_USER;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.USER_NAME_HAS_ALREADY_EXISTED),
                -2 => throw new BadRequestException(ErrorMessages.USER_EMAIL_HAS_ALREADY_EXISTED),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<bool> ChangePassword(ChangePasswordRequestDto request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_NAME, request.UserName, DbType.String);
            parameters.Add(SqlParameters.NEW_PASSWORD_HASH, request.NewPasswordHash, DbType.String);

            var procedureName = ProcedureNames.User.CHANGE_PASSWORD;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_USER_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<IEnumerable<GetFriendOfUserResponse>> GetFriendsOfUser(Guid userID)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_ID, userID, DbType.Guid);
            parameters.Add(SqlParameters.ACTION_STATUS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.User.GET_ALL_FRIENDS_OF_USER;
            var data = await _dbConnection.QueryAsync<GetFriendOfUserResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var actionStatus = parameters.Get<int>(SqlParameters.ACTION_STATUS);

            return actionStatus switch
            {
                0 => data,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_USER_ID),
                -2 => null,
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<GetUserResponse> GetUserById(Guid userID)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_ID, userID, DbType.Guid);
            parameters.Add(SqlParameters.ACTION_STATUS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.User.GET_USER_BY_ID;
            var data = await _dbConnection.QueryFirstAsync<GetUserResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var actionStatus = parameters.Get<int>(SqlParameters.ACTION_STATUS);

            return actionStatus switch
            {
                0 => data,
                -1 => throw new BadRequestException(ErrorMessages.INVALID_USER_ID),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<IEnumerable<GetUserDto>> GetAllUser()
        {
            var procedureName = ProcedureNames.User.GET_ALL_USER;
            var data = await _dbConnection.QueryAsync<GetUserDto>(procedureName, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<bool> AddUserAzureAD(AddUserAzureADDto userDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_NAME, userDto.Username, DbType.String);
            parameters.Add(SqlParameters.USER_EMAIL, userDto.Email, DbType.String);
            parameters.Add(SqlParameters.ROLE, userDto.Role, DbType.String);
            parameters.Add(SqlParameters.LAST_LOGIN_TIME, userDto.LastLoginTime, DbType.DateTime);

            var procedureName = ProcedureNames.User.ADD_USER_AZURE_AD;
            var actionStatus = await _dbConnection.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return actionStatus switch
            {
                0 => true,
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }

        public async Task<FindUserAzureByUserName> FindUserAzureByUserName(string userName)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.USER_NAME, userName, DbType.String);
            parameters.Add(SqlParameters.ACTION_STATUS, DbType.Int32, direction: ParameterDirection.Output);

            var procedureName = ProcedureNames.User.FIND_USER_AZURE_BY_USER_NAME;
            var response = await _dbConnection.QueryFirstAsync<FindUserAzureByUserName>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var actionStatus = parameters.Get<int>(SqlParameters.ACTION_STATUS);

            return actionStatus switch
            {
                0 => response,
                -1 => throw new NotFoundException(ErrorMessages.INVALID_USER_NAME),
                _ => throw new BadRequestException(ErrorMessages.SQL_EXCEPTION)
            };
        }
        #endregion
    }
}
