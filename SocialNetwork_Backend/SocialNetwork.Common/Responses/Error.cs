namespace SocialNetwork.Common.Responses
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public Error() { }

        public Error(int code)
        {
            Code = code;
        }

        public Error(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
