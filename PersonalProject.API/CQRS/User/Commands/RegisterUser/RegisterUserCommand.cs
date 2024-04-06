using System.Security.Permissions;
using AppService.API.Application.User.Model;
using MediatR;
using PersonalProject.Utilities;
using PersonalProject.Utils;

namespace PersonalProject.API.CQRS.User.Commands.RegisterUser
{
    public class RegisterUserCommand: IRequest<ApiResponseDto>
    {
       
        public int cat_id { get; set; }
        public string name { get; set; }
          public string password { get; set; }
        public int RoleId { get; set; }
        
    }
}
