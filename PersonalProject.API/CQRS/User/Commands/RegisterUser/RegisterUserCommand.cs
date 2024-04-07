using System.Security.Permissions;
using MediatR;
using Microsoft.Graph.Models;
using PersonalProject.Utilities;
using PersonalProject.Utils;

namespace PersonalProject.API.CQRS.User.Commands.RegisterUser
{
    public class RegisterUserCommand: IRequest<ApiResponseDto>
    {
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }

    }
}
