using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PersonalProject.Domain.Entities
{
    public class Users
    {
        [Key]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Picture { get; set; }

    }
}