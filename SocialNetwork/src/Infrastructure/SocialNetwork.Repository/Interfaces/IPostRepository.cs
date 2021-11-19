using SocialNetwork.Data.Dtos.Post;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<bool> CreatePost(CreatePostRequestDto request);
    }
}
