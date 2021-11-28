using FluentValidation;
using SocialNetwork.Domain.Commands.Friend;
using System;

namespace SocialNetwork.Domain.Validations.Friend
{
    public class SendFriendRequestCommandValidator : AbstractValidator<SendFriendRequestCommand>
    {
        public SendFriendRequestCommandValidator()
        {
            RuleFor(x => x.ReceiverID).NotEqual(Guid.Empty);
        }
    }
}
