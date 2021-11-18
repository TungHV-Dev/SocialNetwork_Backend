using MediatR;

namespace SocialNetwork.Common.Domain.Request
{
    public class Query : IRequest
    {

    }

    public class Query<T> : IRequest<T>
    {

    }
}
