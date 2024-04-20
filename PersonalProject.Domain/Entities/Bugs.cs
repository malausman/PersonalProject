using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PersonalProject.Domain.Entities
{
    public class Bugs
    {
       
        public int Bug_id { get; set; }
        public int Requirement_id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Severity { get; set; }
        public string Resolution { get; set; }
        public string OperatingSystem { get; set; }
        public string WhereFound { get; set; }
        public DateTime IdentifiedDate { get; set; }
        public string ReportedBy { get; set; }
        public string Description { get; set; }


    }
}