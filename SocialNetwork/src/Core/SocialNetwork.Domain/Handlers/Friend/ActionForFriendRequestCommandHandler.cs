using AutoMapper;
using MediatR;
using SocialNetwork.Data.Dtos.Friend;
using SocialNetwork.Domain.Commands.Friend;
using SocialNetwork.Repository.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Friend
{
    public class ActionForFriendRequestCommandHandler : IRequestHandler<ActionForFriendRequestCommand, bool>
    {
        #region Fields
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public ActionForFriendRequestCommandHandler(IFriendRepository friendRepository, IMapper mapper)
        {
            _friendRepository = friendRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Functions
        public async Task<bool> Handle(ActionForFriendRequestCommand request, CancellationToken cancellationToken)
        {
            var requestDto = _mapper.Map<ActionForFriendRequestDto>(request);
            var response = await _friendRepository.ActionForFriendRequest(requestDto);

            return response;
        }
        #endregion
    }
}
