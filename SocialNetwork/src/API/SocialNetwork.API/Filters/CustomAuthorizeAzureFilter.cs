using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Common.Models;
using SocialNetwork.Repository.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.API.Filters
{
    public class CustomAuthorizeAzureFilter : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Contructor
        public CustomAuthorizeAzureFilter(string roles, ISecurityDataProvider securityDataProvider, IUserRepository userRepository)
        {
            if (!string.IsNullOrEmpty(roles))
            {
                Roles = roles;
            }

            _securityDataProvider = securityDataProvider;
            _userRepository = userRepository;
        }
        #endregion

        #region Public Function
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault().Split(" ")[1];
            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var userName = jsonToken.Claims.First(x => x.Type == "name")?.Value ?? string.Empty;
            var email = jsonToken.Claims.First(x => x.Type == "unique_name")?.Value ?? string.Empty;

            var user = await _userRepository.FindUserAzureByUserName(userName);
            if (user == null)
            {
                throw new BadRequestException(ErrorMessages.INVALID_USER_NAME);
            }

            var roles = Roles.Split(",");
            if(!roles.Contains(user.Role))
            {
                throw new BadRequestException(ErrorMessages.INVALID_USER_ROLE);
            }

            _securityDataProvider.SetUserData(new UserData { UserID = user.UserID, UserName = userName, UserEmail = email});
        }
        #endregion
    }
}
