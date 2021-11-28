using MediatR;
using SocialNetwork.Data.Responses.Friend;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Domain.Queries.User
{
    public class GetFriendsOfUserQuery : IRequest<IEnumerable<GetFriendOfUserResponse>>
    {
        public Guid UserID { get; set; }
    }
}
