namespace SocialNetwork.Data.Requests.Authentication
{
    public class GenerateJwtTokenRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
