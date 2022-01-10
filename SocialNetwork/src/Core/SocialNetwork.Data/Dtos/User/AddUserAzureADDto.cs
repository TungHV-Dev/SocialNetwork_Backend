using System;

namespace SocialNetwork.Data.Dtos.User
{
    public class AddUserAzureADDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
