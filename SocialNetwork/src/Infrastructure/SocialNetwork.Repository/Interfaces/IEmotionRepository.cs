using SocialNetwork.Data.Dtos.Emotion;
using SocialNetwork.Data.Responses.Emotion;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface IEmotionRepository
    {
        Task<bool> ExpressEmotionToPost(ExpressEmotionRequestDto request);
        Task<GetAllEmotionResponse> GetAllEmotionOfPost(GetAllEmotionRequestDto request);
        Task<GetAllUserResponse> GetEmotionUserOfPost(GetEmotionUserRequestDto request);
    }
}
