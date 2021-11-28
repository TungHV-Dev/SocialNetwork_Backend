using System;

namespace SocialNetwork.Data.Dtos.User
{
    public class GetUserDto
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int TotalPosts { get; set; }
    }
}
