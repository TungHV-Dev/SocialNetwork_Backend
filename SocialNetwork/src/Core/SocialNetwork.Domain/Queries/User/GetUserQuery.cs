using MediatR;
using SocialNetwork.Data.Responses.User;
using System;

namespace SocialNetwork.Domain.Queries.User
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public Guid UserID { get; set; }
    }
}
