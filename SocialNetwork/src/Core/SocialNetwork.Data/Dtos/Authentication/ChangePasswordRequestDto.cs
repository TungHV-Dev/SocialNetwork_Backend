using System;

namespace SocialNetwork.Data.Dtos.Authentication
{
    public class ChangePasswordRequestDto
    {
        public string UserName { get; set; }
        public string NewPasswordHash { get; set; }
    }
}
