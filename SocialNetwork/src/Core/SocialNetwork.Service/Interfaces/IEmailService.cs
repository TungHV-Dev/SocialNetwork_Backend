using SocialNetwork.Data.Requests.Email;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
