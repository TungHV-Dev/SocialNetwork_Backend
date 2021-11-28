using MediatR;
using System.IO;

namespace SocialNetwork.Domain.Queries.ExportData
{
    public class ExportListUserQuery : IRequest<MemoryStream>
    {

    }
}
