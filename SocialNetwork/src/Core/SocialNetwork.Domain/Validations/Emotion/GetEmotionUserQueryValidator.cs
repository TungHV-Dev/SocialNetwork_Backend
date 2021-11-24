using FluentValidation;
using SocialNetwork.Common.Enums;
using SocialNetwork.Domain.Queries.Emotion;

namespace SocialNetwork.Domain.Validations.Emotion
{
    public class GetEmotionUserQueryValidator : AbstractValidator<GetEmotionUserQuery>
    {
        public GetEmotionUserQueryValidator()
        {
            RuleFor(x => x.Status).NotEqual(EmotionStatus.NoEmotion);
        }
    }
}
