using MediatR;
using PersonalProject.CommonUtilities;
using PersonalProject.Domain.IRepositories;
using Newtonsoft.Json;
using PersonalProject.Domain.Entities;

namespace PersonalProject.API.CQRS.CreateBugs.Commands.CreateBugCommand
{
    public class CreateBugCommandHandler : IRequestHandler<CreateBugCommand, ApiResponseDTO>
    {
        private readonly IBugsRepository _commentRepository;
        public CreateBugCommandHandler(IBugsRepository userRepository)
        {
            _commentRepository = userRepository;
        }
        public async Task<ApiResponseDTO> Handle(CreateBugCommand request, CancellationToken cancellationToken)
        {
            var bug = new Domain.Entities.Bugs
            {
                Requirement_id = request.Requirement_id,
                Title = request.Title,
                Priority = request.Priority,
                Status = request.Status,
                Severity = request.Severity,
                Resolution = request.Resolution,
                OperatingSystem = request.OperatingSystem,
                WhereFound = request.WhereFound,
                IdentifiedDate = request.IdentifiedDate,
                ReportedBy = request.ReportedBy,
                Description = request.Description

            };
            var res=await _commentRepository.AddAsync(bug);
            if (res == -1)
            {
                return ApiResponse.Ok("This bug already exists!");
            }
            else
            {
                return ApiResponse.Ok("New bug created successfully!");
            }

             
        }
    }
}
