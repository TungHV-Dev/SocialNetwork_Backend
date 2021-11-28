namespace SocialNetwork.Common.Enums
{
    public enum FriendRequestStatus
    {
        Pending,
        Accept,
        Reject
    }

    public enum ActionForFriendRequest
    {
        Accept = FriendRequestStatus.Accept,
        Reject = FriendRequestStatus.Reject
    }
}
