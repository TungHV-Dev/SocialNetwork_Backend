using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Filters;

namespace SocialNetwork.API.Attributes
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute() : base(typeof(CustomAuthorizeFilter))
        {
        }
    }
}
