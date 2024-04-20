using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using MediatR;
using Newtonsoft.Json;
using PersonalProject.Domain.Entities;
using PersonalProject.CommonUtilities;
using System.ComponentModel;

namespace PersonalProject.API.CQRS.CreateBugs.Commands.CreateBugCommand
{
    public class CreateBugCommand : IRequest<ApiResponseDTO>
    {
        [Key]
        public int Bug_id { get; set; }
        public int Requirement_id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Severity { get; set; }
        public string Resolution { get; set; }
        public string OperatingSystem { get; set; }
        public string WhereFound{ get; set; }
    public DateTime IdentifiedDate { get; set; }
    public string ReportedBy { get; set; }
    public string Description { get; set; }
}
}
