using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Filters;

namespace SocialNetwork.API.Attributes
{
    public class CustomAuthorizeAzureAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAzureAttribute(string permissions = "") : base(typeof(CustomAuthorizeAzureFilter))
        {
            Arguments = new object[] { permissions };
        }
    }
}
