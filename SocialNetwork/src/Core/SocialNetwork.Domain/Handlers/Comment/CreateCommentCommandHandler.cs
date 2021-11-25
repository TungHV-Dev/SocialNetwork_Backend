using AutoMapper;
using MediatR;
using SocialNetwork.Common.Authorization;
using SocialNetwork.Data.Dtos.Comment;
using SocialNetwork.Data.Responses.Comment;
using SocialNetwork.Domain.Commands.Comment;
using SocialNetwork.Repository.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Handlers.Comment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
    {
        #region Fields
        private readonly ISecurityDataProvider _securityDataProvider;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public CreateCommentCommandHandler(ISecurityDataProvider securityDataProvider, ICommentRepository commentRepository, IMapper mapper)
        {
            _securityDataProvider = securityDataProvider;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        #endregion

        #region
        public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var requestDto = _mapper.Map<CreateCommentRequestDto>(request);
            requestDto.UserID = _securityDataProvider.GetUserData().UserID;

            var data = await _commentRepository.CreateComment(requestDto);
            return data;
        }
        #endregion
    }
}
