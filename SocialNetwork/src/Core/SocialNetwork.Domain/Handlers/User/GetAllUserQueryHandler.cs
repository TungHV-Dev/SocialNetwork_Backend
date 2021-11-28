using MediatR;
using SocialNetwork.Data.Dtos.User;
using SocialNetwork.Domain.Queries.User;
using SocialNetwork.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.User
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<GetUserDto>>
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region Contructor
        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        #region Public Functions
        public async Task<IEnumerable<GetUserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var data = await _userRepository.GetAllUser();
            return data;
        }
        #endregion
    }
}
