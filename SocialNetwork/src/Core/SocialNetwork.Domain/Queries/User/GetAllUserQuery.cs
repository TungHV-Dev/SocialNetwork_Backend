using MediatR;
using SocialNetwork.Data.Dtos.User;
using System.Collections.Generic;

namespace SocialNetwork.Domain.Queries.User
{
    public class GetAllUserQuery : IRequest<IEnumerable<GetUserDto>>
    {

    }
}
