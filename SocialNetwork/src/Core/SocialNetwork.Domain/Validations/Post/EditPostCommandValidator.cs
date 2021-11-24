using FluentValidation;
using SocialNetwork.Domain.Commands.Post;
using System;

namespace SocialNetwork.Domain.Validations.Post
{
    public class EditPostCommandValidator : AbstractValidator<EditPostCommand>
    {
        public EditPostCommandValidator()
        {
            RuleFor(x => x.PostID).NotEqual(Guid.Empty);
            RuleFor(x => x.Content).NotNull();
        }
    }
}
