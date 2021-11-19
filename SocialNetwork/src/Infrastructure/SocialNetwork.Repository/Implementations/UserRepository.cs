using Dapper;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Data.Dtos.User;
using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Repository.Interfaces;
using System.Data;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

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

        public async Task<bool> RegisterNewUser(RegisterRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add(SqlParameters.FIRST_NAME, request.FirstName, DbType.String);
            parameters.Add(SqlParameters.LAST_NAME, request.LastName, DbType.String);
            parameters.Add(SqlParameters.USER_NAME, request.Username, DbType.String);
            parameters.Add(SqlParameters.USER_EMAIL, request.Email, DbType.String);
            parameters.Add(SqlParameters.PASSWORD, request.Password, DbType.String);
            parameters.Add(SqlParameters.IS_PUBLIC_ACCOUNT, request.IsPublicAccount, DbType.Boolean);

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
    }
}
