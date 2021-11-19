using System;

namespace SocialNetwork.Common.Models
{
    public class UserData
    {
        public Guid UserID { get; set; } = Guid.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
