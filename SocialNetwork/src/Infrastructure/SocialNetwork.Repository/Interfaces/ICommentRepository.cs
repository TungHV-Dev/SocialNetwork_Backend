using SocialNetwork.Data.Dtos.Comment;
using SocialNetwork.Data.Responses.Comment;
using System;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task<CreateCommentResponse> CreateComment(CreateCommentRequestDto request);
        Task<bool> DeleteComment(Guid commentID);
        Task<bool> EditComment(EditCommentRequestDto request);
        Task<GetAllCommentResponse> GetAllComment(GetAllCommentRequestDto request);
    }
}
