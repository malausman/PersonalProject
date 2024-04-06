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
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ApiResponseDto> RegisterUser(RegisterUserCommand model)
        {
            return await Mediator.Send(model);

        }
    }
}