using MediatR;
using System;

namespace SocialNetwork.Domain.Commands.Authentication
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
