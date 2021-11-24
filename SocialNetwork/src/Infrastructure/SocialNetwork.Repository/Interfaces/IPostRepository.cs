using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Data.Responses.Post;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<CreatePostResponse> CreatePost(CreatePostRequestDto request);
        Task<bool> DeletePost(DeletePostRequestDto request);
        Task<GetAllPostsResponse> GetAllPosts(GetAllPostsRequestDto request);
        Task<bool> EditPost(EditPostRequestDto request);
    }
}
