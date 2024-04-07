using FluentValidation;
using PersonalProject.API.CQRS.User.Commands.RegisterUser;

namespace PersonalProject.API.Application.Validations
{
    public class RegisterUserCommandValidator: AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator(ILogger<RegisterUserCommandValidator> logger)
        {
           // RuleFor(user => user.userid).NotEmpty().WithMessage("Userid is required");
           //RuleFor(user => user.operid).NotEmpty().WithMessage("Operationid is required");
            RuleFor(user => user.name).NotEmpty().WithMessage("Name is required");
            RuleFor(user => user.password).NotEmpty().WithMessage("Password is required");
            RuleFor(user => user.email).NotEmpty().WithMessage("email is required");
        }
    }
}
