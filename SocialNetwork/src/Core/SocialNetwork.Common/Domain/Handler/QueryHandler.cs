using AutoMapper;
using MediatR;
using SocialNetwork.Common.Domain.MediatorExtension;
using SocialNetwork.Common.Domain.Request;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Common.Domain.Handler
{
    public abstract class QueryHandler<T> : IRequestHandler<T> where T : Query
    {
        protected readonly IMediatorExtend _mediator;
        protected readonly IMapper _mapper;

        protected QueryHandler(IMediatorExtend mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public abstract Task<Unit> Handle(T request, CancellationToken cancellationToken);
    }

    public abstract class QueryHandler<T, TResponse> : IRequestHandler<T, TResponse> where T : Query<TResponse>
    {
        protected readonly IMediatorExtend _mediator;
        protected readonly IMapper _mapper;

        protected QueryHandler(IMediatorExtend mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public abstract Task<TResponse> Handle(T request, CancellationToken cancellationToken);
    }
}
