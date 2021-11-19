using Microsoft.AspNetCore.Mvc.Filters;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Common.Models;
using System.Linq;
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
            var userEmail = context.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var userName = context.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            _securityDataProvider.SetUserData(new UserData { UserEmail = userEmail, UserName = userName });
        }
        #endregion
    }
}
