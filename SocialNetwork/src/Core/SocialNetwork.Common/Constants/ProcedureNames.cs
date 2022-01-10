namespace SocialNetwork.Common.Constants
{
    public static class ProcedureNames
    {
        public static class Comment
        {
            public const string CREATE_COMMENT = "sp_CreateComment";
            public const string DELETE_COMMENT = "sp_DeleteComment";
            public const string EDIT_COMMENT = "sp_EditComment";
            public const string GET_ALL_COMMENT = "sp_GetAllComment";
        }

        public static class Emotion
        {
            public const string EXPRESS_EMOTION = "sp_ExpressEmotion";
            public const string GET_ALL_EMOTIONS = "sp_GetAllEmotions";
            public const string GET_EMOTION_USER = "sp_GetEmotionUser";
        }

        public static class Friend
        {
            public const string SEND_FRIEND_REQUEST = "sp_SendFriendRequest";
            public const string CANCEL_FRIEND_REQUEST = "sp_CancelFriendRequest";
            public const string ACTION_FOR_FRIEND_REQUEST = "sp_ActionForFriendRequest";
            public const string UNFRIEND_WITH_ANOTHER_USER = "sp_UnfriendWithAnotherUser";
            public const string GET_ALL_PENDING_FRIEND_REQUEST = "sp_GetAllPendingFriendRequest";
        }

        public static class Post
        {
            public const string CREATE_POST = "sp_CreatePost";
            public const string DELETE_POST = "sp_DeletePost";
            public const string EDIT_POST = "sp_EditPost";
            public const string GET_ALL_POSTS_IN_TIMELINE = "sp_GetAllPostsInTimeline";
            public const string GET_ALL_POSTS_OF_USER = "sp_GetAllPostsOfUser";
        }

        public static class User
        {
            public const string FIND_USER_BY_USER_NAME = "sp_FindUserByUserName";
            public const string FIND_USER_AZURE_BY_USER_NAME = "sp_FindUserAzureByUserName";
            public const string REGISTER_NEW_USER = "sp_RegisterNewUser";
            public const string CHANGE_PASSWORD = "sp_ChangePassword";
            public const string GET_ALL_FRIENDS_OF_USER = "sp_GetAllFriendOfUser";
            public const string GET_USER_BY_ID = "sp_GetUserById";
            public const string GET_ALL_USER = "sp_GetAllUser";
            public const string ADD_USER_AZURE_AD = "sp_AddUserAzureAD";
        }
    }
}
