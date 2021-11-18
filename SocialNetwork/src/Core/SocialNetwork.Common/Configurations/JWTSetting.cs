namespace SocialNetwork.Common.Configurations
{
    public class JWTSetting
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
