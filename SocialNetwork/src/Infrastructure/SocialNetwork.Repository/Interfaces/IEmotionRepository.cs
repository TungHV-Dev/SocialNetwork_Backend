using SocialNetwork.Data.Dtos.Emotion;
using SocialNetwork.Data.Responses.Emotion;
using System;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Interfaces
{
    public interface IEmotionRepository
    {
        Task<bool> ExpressEmotionToPost(ExpressEmotionRequestDto request);
        Task<GetAllEmotionResponse> GetAllEmotionOfPost(Guid postID);
        Task<GetAllUserResponse> GetEmotionUserOfPost(GetEmotionUserRequestDto request);
    }
}
