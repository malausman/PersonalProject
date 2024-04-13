using MediatR;
using PersonalProject.Domain.IRepositories;
using PersonalProject.Utils;

namespace PersonalProject.API.CQRS.User.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApiResponseDto>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            //request.password = request.password.ComputeSha256Hash();
            var user = new Domain.Entities.userInfo
            {
               
               //cat_id = request.cat_id,
               //name = request.name,
               //password = request.password,
               // RoleId =request.RoleId,
              
            };
            var res=await _userRepository.AddAsync(user);
            if (res == -1)
            {
                return ApiResponse.Ok("user already exists");
            }
            else
            {
                return ApiResponse.Ok("New user created successfully");
            }

          //  return AppServicesResponse.OkResponse("New user created successfully");
        }
    }
}
