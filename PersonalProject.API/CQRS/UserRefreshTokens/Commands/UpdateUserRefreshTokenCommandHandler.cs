using PersonalProject.API.CQRS.Services;
using PersonalProject.Domain.Entities;
using MediatR;
using PersonalProject.Utils;
using PersonalProject.Utils.ClaimManager;
using Services.Common;
using Services.Common.Utils;
using PersonalProject.Domain.Repositories;
using PersonalProject.API.CQRS.UserRefreshTokens.Model;

namespace PersonalProject.API.CQRS.UserRefreshTokens.Commands
{
    public class UpdateUserRefreshTokenCommandHandler : IRequestHandler<UpdateUserRefreshTokenCommand, ApiResponseDto>
    {
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
        private readonly ITokenService _tokenService;
        private readonly IClaimsManager _claimsManager;
        public UpdateUserRefreshTokenCommandHandler(IUserRefreshTokenRepository userRefreshTokenRepository, ITokenService tokenService, IClaimsManager claimsManager)
        {
            _userRefreshTokenRepository = userRefreshTokenRepository;
            _tokenService = tokenService;
            _claimsManager = claimsManager;
        }
        public async Task<ApiResponseDto> Handle(UpdateUserRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userModel = _claimsManager.GetUserModel();
            var isRefreshTokenExist = await _userRefreshTokenRepository.GetUserRefreshToken(request.userId, userModel.RefreshTokenID);
            if (isRefreshTokenExist!=null && isRefreshTokenExist.RefreshTokenExpiry>=DateTime.Now)
            {
                var principal = _tokenService.GetPrincipalFromExpiredToken(request.accessToken);
                var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
                var newRefreshToken = _tokenService.GenerateRefreshToken();

                var refreshTokenModel = new UserRefreshToken()
                {
                    UserId = request.userId,
                    Token = newRefreshToken,
                    Id = userModel.RefreshTokenID,
                };
                await _userRefreshTokenRepository.UpdateAsync(refreshTokenModel);
                var UpdatedRefreshToken = new UserRefreshTokenDto
                {
                    UserId = request.userId,
                    RefreshToken = newRefreshToken,
                    AccessToken = newJwtToken
                };
                return ApiResponse.Ok(UpdatedRefreshToken);
            }
            else
            {
                return ApiResponse.UnauthorizedResponse("Refresh Token Not found");
            }

        }
    }
}
