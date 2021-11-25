using AutoMapper;
using MediatR;
using SocialNetwork.Data.Dtos.Comment;
using SocialNetwork.Domain.Commands.Comment;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Comment
{
    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, bool>
    {
        #region Fields
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public EditCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Functions
        public async Task<bool> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var requestDto = _mapper.Map<EditCommentRequestDto>(request);
            var data = await _commentRepository.EditComment(requestDto);

            return data;
        }
        #endregion
    }
}
