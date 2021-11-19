using System;

namespace SocialNetwork.Data.Responses.Authentication
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string JWToken { get; set; }
    }
}
