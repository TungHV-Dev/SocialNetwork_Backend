using System;

namespace SocialNetwork.Data.Dtos.User
{
    public class FindUserAzureByUserName
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
