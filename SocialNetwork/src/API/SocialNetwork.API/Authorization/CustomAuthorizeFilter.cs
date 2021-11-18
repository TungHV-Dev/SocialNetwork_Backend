using Microsoft.AspNetCore.Mvc.Filters;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Common.Models;
using System.Linq;
using System.Security.Claims;

namespace SocialNetwork.API.Authorization
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
            var userEmail = context.HttpContext.User.Identity.Name;
            var claims = context.HttpContext.User.Claims;
            var fullName = claims.FirstOrDefault(x => string.Compare(x.Type, ClaimTypes.Name, false) == 0)?.Value;

            _securityDataProvider.SetUserData(new UserData { UserEmail = userEmail, FullName = fullName });
        }
        #endregion
    }
}
