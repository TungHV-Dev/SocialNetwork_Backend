using System;

namespace SocialNetwork.Data.Dtos.Post
{
    public class DeletePostRequestDto
    {
        public Guid PostID { get; set; }
        public Guid UserID { get; set; }
    }
}
