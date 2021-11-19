using MediatR;

namespace SocialNetwork.Domain.Commands.Authentication
{
    public class RegisterCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsPublicAccount { get; set; }
	}
}
