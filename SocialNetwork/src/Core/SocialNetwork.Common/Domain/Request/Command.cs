using MediatR;

namespace SocialNetwork.Common.Domain.Request
{
    public class Command : IRequest
    {

    }

    public class Command<T> : IRequest<T>
    {

    }
}
