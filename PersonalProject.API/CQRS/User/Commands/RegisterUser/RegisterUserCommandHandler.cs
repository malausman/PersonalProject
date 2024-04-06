using MediatR;
using Services.Common;
using Services.Common.Utils;
using PersonalProject.Utils;
using PersonalProject.API.CQRS.User.Commands.RegisterUser;
using PersonalProject.Domain.IRepositories;
using PersonalProject.Common;

namespace PersonalProject.API.Application.User.Commands.RegisterUser
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
             request.password = request.password.ComputeSha256Hash();
            var user = new Domain.Entities.userInfo
            {
                 name = request.name,
                password = request.password,
            };
             var res=await _userRepository.AddAsync(user);
            if (res == -1)
            {
                return AppServicesResponse.OkResponse("user already exists");
            }
            else
            {
                return AppServicesResponse.OkResponse("New user created successfully");
            }

             
        }
    }
}
