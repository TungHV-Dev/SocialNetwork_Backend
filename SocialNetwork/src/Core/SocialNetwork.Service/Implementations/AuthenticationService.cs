using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Common.Configurations;
using SocialNetwork.Common.Constants;
using SocialNetwork.Data.Requests.Authentication;
using SocialNetwork.Data.Responses.Authentication;
using SocialNetwork.Repository.Interfaces;
using SocialNetwork.Service.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        private readonly JWTSetting _jwtSetting;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public AuthenticationService(IUserRepository userRepository, IOptions<JWTSetting> jwtSetting, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtSetting = jwtSetting.Value;
            _mapper = mapper;
        }
        #endregion

        #region Public Functions
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userRepository.FindUserByUserName(request.Username);

            var generateRequest = _mapper.Map<GenerateJwtTokenRequest>(user);
            JwtSecurityToken jwtSecurityToken = GenerateJWToken(generateRequest);

            var response = _mapper.Map<AuthenticationResponse>(user);
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return response;
        }

        #endregion

        #region Private Functions
        private JwtSecurityToken GenerateJWToken(GenerateJwtTokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(CustomClaimTypes.Name, request.UserName),
                    new Claim(CustomClaimTypes.Email, request.Email),
                    new Claim(CustomClaimTypes.Role, request.Role)
                }),
                Issuer = _jwtSetting.Issuer,
                Audience = _jwtSetting.Audience,
                Expires = DateTime.UtcNow.AddMinutes(_jwtSetting.DurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return token;
        }

        #endregion
    }
}
