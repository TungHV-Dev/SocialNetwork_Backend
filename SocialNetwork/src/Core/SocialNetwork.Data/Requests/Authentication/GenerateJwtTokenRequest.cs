using System;

namespace SocialNetwork.Data.Requests.Authentication
{
    public class GenerateJwtTokenRequest
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
