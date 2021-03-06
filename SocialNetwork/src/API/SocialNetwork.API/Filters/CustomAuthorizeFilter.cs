using Microsoft.AspNetCore.Mvc.Filters;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Models;
using System;
using System.Security.Claims;

namespace SocialNetwork.API.Filters
{
    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        #endregion

        #region Contructor
        public CustomAuthorizeFilter(ISecurityDataProvider securityDataProvider)
        {
            _securityDataProvider = securityDataProvider;
        }
        #endregion

        #region Public Function
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userID = Guid.Parse(context.HttpContext.User.FindFirstValue(CustomClaimTypes.UserID));
            var userEmail = context.HttpContext.User.FindFirstValue(CustomClaimTypes.Email);
            var userName = context.HttpContext.User.FindFirstValue(CustomClaimTypes.Name);

            _securityDataProvider.SetUserData(new UserData { UserID = userID, UserEmail = userEmail, UserName = userName });
        }
        #endregion
    }
}
