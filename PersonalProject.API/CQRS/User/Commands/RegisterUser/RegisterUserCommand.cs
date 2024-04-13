using System.Security.Permissions;
using MediatR;
using PersonalProject.Utils;
using Services.Common;
using Services.Common.Utils;

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
