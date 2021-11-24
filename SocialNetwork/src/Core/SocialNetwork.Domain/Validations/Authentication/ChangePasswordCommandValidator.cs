using FluentValidation;
using SocialNetwork.Common.Constants;
using SocialNetwork.Domain.Commands.Authentication;

namespace SocialNetwork.Domain.Validations.Authentication
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.NewPassword).Equal(x => x.ConfirmPassword).WithMessage(ErrorMessages.INCORRECT_CONFIRM_PASSWORD);
        }
    }
}
