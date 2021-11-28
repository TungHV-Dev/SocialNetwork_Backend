using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Data.Responses.Post;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<CreatePostResponse> CreatePost(CreatePostRequestDto request);
        Task<bool> DeletePost(DeletePostRequestDto request);
        Task<bool> EditPost(EditPostRequestDto request);
        Task<GetAllPostsInTimelineResponse> GetAllPostsInTimeline(GetAllPostsInTimelineRequestDto request);
        Task<GetAllPostsOfUserResponse> GetAllPostsOfUser(GetAllPostsOfUserRequestDto request);
    }
}
