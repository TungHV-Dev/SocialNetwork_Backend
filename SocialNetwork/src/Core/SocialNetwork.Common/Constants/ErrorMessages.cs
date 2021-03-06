namespace SocialNetwork.Common.Constants
{
    public class ErrorMessages
    {
        public const string SQL_EXCEPTION = "An SQL exception has occured.";

        public const string INVALID_USER_ID = "User id does not exist.";
        public const string INVALID_USER_NAME = "User name does not exist.";
        public const string USER_NAME_HAS_ALREADY_EXISTED = "User name has already existed.";
        public const string USER_EMAIL_HAS_ALREADY_EXISTED = "User email has already existed.";
        public const string INCORRECT_PASSWORD = "Password is incorrect.";
        public const string INCORRECT_CONFIRM_PASSWORD = "New password and confirmation password must be the same";

        public const string INVALID_POST_ID = "Post id does not exist";
        public const string NOT_FOUND_ANY_POSTS = "Did not find any posts yet";

        public const string INVALID_COMMENT_ID = "Comment id does not exist";

        public const string INVALID_REQUEST_ID = "Request id does not exist";
        public const string INVALID_RECEIVER_ID = "Receiver id does not exist";
        public const string INVALID_FRIEND_ID = "Friend id does not exist";
        public const string IS_PENDING_OR_HAVE_BEEN_FRIENDS = "Your request is pending or you and receiver have been friends";
        public const string REQUEST_IS_ACCEPTED_OR_REJECTED = "Your request is accepted or rejected";
        public const string NOT_FRIENDS = "You guys are not friends";

        public const string INVALID_USER_ROLE = "User does not have permission to perform this action";
    }
}
