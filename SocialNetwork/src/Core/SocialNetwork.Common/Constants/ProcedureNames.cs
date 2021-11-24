namespace SocialNetwork.Common.Constants
{
    public static class ProcedureNames
    {
        public static class Comment
        {

        }

        public static class Friend
        {

        }

        public static class Emotion
        {
            public const string EXPRESS_EMOTION = "sp_ExpressEmotion";
            public const string GET_ALL_EMOTIONS = "sp_GetAllEmotions";
            public const string GET_EMOTION_USER = "sp_GetEmotionUser";
        }

        public static class Message
        {

        }

        public static class Post
        {
            public const string CREATE_POST = "sp_CreatePost";
            public const string DELETE_POST = "sp_DeletePost";
            public const string GET_ALL_POSTS = "sp_GetAllPosts";
            public const string EDIT_POST = "sp_EditPost";
        }

        public static class User
        {
            public const string FIND_USER_BY_USER_NAME = "sp_FindUserByUserName";
            public const string REGISTER_NEW_USER = "sp_RegisterNewUser";
            public const string CHANGE_PASSWORD = "sp_ChangePassword";
        }
    }
}
