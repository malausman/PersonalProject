using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalProject.API.CQRS.User.Commands.RegisterUser;
using PersonalProject.Utils;

namespace PersonalProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : DefaultController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ApiResponseDto> RegisterUser(RegisterUserCommand model)
        {
            if (model == null)
            {
                return ApiResponse.BadRequest("Model is null");
            }
            return await _mediator.Send(model);

        }
        [AllowAnonymous]
        [HttpPost("register1")]
        public async Task<ApiResponseDto> RegisterUser1(RegisterUserCommand model)
        {
            return await Mediator.Send(model);

        }
    }
}