using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalProject.API.CQRS.User.Commands.createPost;
using PersonalProject.Utils;

namespace PersonalProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsControlle : DefaultController
    {
        private readonly IMediator _mediator;
        public PostsControlle(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost("createPost")]
        public async Task<ApiResponseDto> createPost(createPostCommand model)
        {
            if (model == null)
            {
                return ApiResponse.BadRequest("Model is null");
            }
            return await _mediator.Send(model);

        }

        
    }
}