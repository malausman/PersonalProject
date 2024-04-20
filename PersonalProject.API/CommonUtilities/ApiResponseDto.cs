using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.CommonUtilities
{
    public class ApiResponseDTO
    {
        public dynamic Response { get; set; }
        public bool IsSuccessful { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }
        public int? Page { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalItems { get; set; }
        public Dictionary<string, string> Links { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, string> Meta { get; set; }
    }
}
