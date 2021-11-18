using SocialNetwork.Common.Domain.Request;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Common.Domain.MediatorExtension
{
    public interface IMediatorExtend
    {
        Task<T> SendCommand<T>(Command<T> command, CancellationToken cancellationToken = default);

        Task SendCommand(Command command, CancellationToken cancellationToken = default);

        Task<T> SendQuery<T>(Query<T> query, CancellationToken cancellationToken = default);

        Task SendQuery(Query query, CancellationToken cancellationToken = default);
    }
}
