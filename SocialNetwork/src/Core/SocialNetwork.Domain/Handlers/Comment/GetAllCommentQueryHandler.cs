using AutoMapper;
using MediatR;
using SocialNetwork.Data.Dtos.Comment;
using SocialNetwork.Data.Responses.Comment;
using SocialNetwork.Domain.Queries.Comment;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Comment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, GetAllCommentResponse>
    {
        #region Fields
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public GetAllCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        #endregion

        #region
        public Task<GetAllCommentResponse> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            var requestDto = _mapper.Map<GetAllCommentRequestDto>(request);
            var data = _commentRepository.GetAllComment(requestDto);
            return data;
        }
        #endregion
    }
}
