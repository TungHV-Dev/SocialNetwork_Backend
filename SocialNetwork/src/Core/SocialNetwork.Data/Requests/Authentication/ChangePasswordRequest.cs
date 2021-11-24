using System;

namespace SocialNetwork.Data.Requests.Authentication
{
    public class ChangePasswordRequest
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
