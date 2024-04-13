using MediatR;
using Services.Common;
using Services.Common.Utils;
using PersonalProject.Utils;
using PersonalProject.Domain.IRepositories;
using PersonalProject.Common;
using Newtonsoft.Json;
using PersonalProject.Domain.Entities;
using PersonalProject.API.CQRS.User.Commands.createComments;

namespace PersonalProject.API.Application.User.Commands.createComment
{
    public class createCommentCommandHandler : IRequestHandler<createCommentCommand, ApiResponseDto>
    {
        private readonly ICommentRepository _commentRepository;
        public createCommentCommandHandler(ICommentRepository userRepository)
        {
            _commentRepository = userRepository;
        }
        public async Task<ApiResponseDto> Handle(createCommentCommand request, CancellationToken cancellationToken)
        {
        var comment = new Domain.Entities.Comment
            {
                Id = request.Id,
                UserId= request.UserId,
                Message= request.Message,
                DateTimeUtc= request.DateTimeUtc,
                 Post = request.Post,
                Likes = request.Likes,
                
            };
             var res=await _commentRepository.AddAsync(comment);
            if (res == -1)
            {
                return ApiResponse.Ok("This comment already exists!");
            }
            else
            {
                return ApiResponse.Ok("New Comment created successfully!");
            }

             
        }
    }
}
