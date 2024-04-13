using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalProject.API.CQRS.User.Commands.createComments;
using PersonalProject.Utils;

namespace PersonalProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : DefaultController
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost("createComments")]
        public async Task<ApiResponseDto> createPost(createCommentCommand model)
        {
            if (model == null)
            {
                return ApiResponse.BadRequest("Model is null");
            }
            return await _mediator.Send(model);

        }
        
    }
}