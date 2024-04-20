using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalProject.API.CQRS.CreateBugs.Commands.CreateBugCommand;
using PersonalProject.CommonUtilities;

namespace PersonalProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddBugsController : DefaultController
    {
        private readonly IMediator _mediator;
        public AddBugsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpPost("createBugs")]
        public async Task<ApiResponseDTO> createPost(CreateBugCommand model)
        {
            if (model == null)
            {
                return ApiResponse.BadRequest("Model is null");
            }
            return await _mediator.Send(model);

        }

    }
}