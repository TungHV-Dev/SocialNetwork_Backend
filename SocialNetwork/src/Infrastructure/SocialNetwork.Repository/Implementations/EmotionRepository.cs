using SocialNetwork.Data.Dtos.Emotion;
using SocialNetwork.Data.Responses.Emotion;
using SocialNetwork.Repository.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Implementations
{
    public class EmotionRepository : IEmotionRepository
    {
        #region Fields
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Contructor
        public EmotionRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        #endregion

        #region
        public Task<bool> ExpressEmotionToPost(ExpressEmotionRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllEmotionResponse> GetAllEmotionOfPost(GetAllEmotionRequestDto request)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
