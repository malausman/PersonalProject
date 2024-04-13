using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var data = new
            {
                name = "John Doe",
                email = "john.doe@example.com",
                dateOfBirth = "01/01/2000" // Slash in the date format
            };

            return Ok(data);
            // Return the JSON response
            
        }

    }
}