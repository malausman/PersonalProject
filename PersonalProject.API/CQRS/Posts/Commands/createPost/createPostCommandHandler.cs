using MediatR;
using Services.Common;
using Services.Common.Utils;
using PersonalProject.Utils;
using PersonalProject.API.CQRS.User.Commands.createPost;
using PersonalProject.Domain.IRepositories;
using PersonalProject.Common;
using Newtonsoft.Json;
using PersonalProject.Domain.Entities;

namespace PersonalProject.API.Application.User.Commands.createPost
{
    public class createCommentCommandHandler : IRequestHandler<createPostCommand, ApiResponseDto>
    {
        private readonly IPostRepository _postRepository;
        public createCommentCommandHandler(IPostRepository userRepository)
        {
            _postRepository = userRepository;
        }
        public async Task<ApiResponseDto> Handle(createPostCommand request, CancellationToken cancellationToken)
        {
            
            var post = new Domain.Entities.Posts
            {
                Id = request.Id,
                UserId= request.UserId,
                Message= request.Message,
                DateTimeUtc= request.DateTimeUtc,
               // Comments = request.Comments,
                Likes = request.Likes,
                
            };
             var res=await _postRepository.AddAsync(post);
            if (res == -1)
            {
                return ApiResponse.Ok("This post already exists!");
            }
            else
            {
                return ApiResponse.Ok("New Post created successfully!");
            }

             
        }
    }
}
