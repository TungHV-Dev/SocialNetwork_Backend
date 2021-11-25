using MediatR;
using SocialNetwork.Domain.Commands.Comment;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Comment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        #region Fields
        private readonly ICommentRepository _commentRepository;
        #endregion

        #region Contructor
        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        #endregion

        #region
        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var data = await _commentRepository.DeleteComment(request.CommentID);
            return data;
        }
        #endregion
    }
}
