using MediatR;
using PersonalProject.Utils;
using Services.Common;
using Services.Common.Utils;

namespace PersonalProject.API.CQRS.UserRefreshTokens.Commands
{
    public class UpdateUserRefreshTokenCommand : IRequest<ApiResponseDto>
    {
        public string userId { get; set; }
        public string accessToken { get; set; }


    }
}
