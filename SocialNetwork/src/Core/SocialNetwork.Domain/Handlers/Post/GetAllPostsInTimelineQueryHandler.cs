using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Common.Constants;
using SocialNetwork.Common.Exceptions;
using SocialNetwork.Data.Dtos.Post;
using SocialNetwork.Data.Responses.Post;
using SocialNetwork.Domain.Queries.Post;
using SocialNetwork.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Post
{
    public class GetAllPostsInTimelineQueryHandler : IRequestHandler<GetAllPostsInTimelineQuery, GetAllPostsInTimelineResponse>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Contructor
        public GetAllPostsInTimelineQueryHandler(
            ISecurityDataProvider securityDataProvider, 
            IPostRepository postRepository, 
            IUserRepository userRepository)
        {
            _securityDataProvider = securityDataProvider;
            _postRepository = postRepository;
            _userRepository = userRepository;

        }
        #endregion

        #region Public Functions
        public async Task<GetAllPostsInTimelineResponse> Handle(GetAllPostsInTimelineQuery request, CancellationToken cancellationToken)
        {
            var userID = _securityDataProvider.GetUserData().UserID;
            var friends = await _userRepository.GetFriendsOfUser(userID);

            if(friends == null)
            {
                throw new NotFoundException(ErrorMessages.NOT_FOUND_ANY_POSTS);
            }

            var friendIds = new List<Guid>();
            foreach(var friend in friends)
            {
                friendIds.Add(friend.FriendID);
            }

            var requestDto = new GetAllPostsInTimelineRequestDto
            {
                FriendIds = friendIds.AsEnumerable(),
                Request = request.Request
            };
            var response = await _postRepository.GetAllPostsInTimeline(requestDto);
            return response;
        }
        #endregion
    }
}
