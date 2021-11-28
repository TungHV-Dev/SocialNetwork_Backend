using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SocialNetwork.Data.Requests.Email
{
    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
