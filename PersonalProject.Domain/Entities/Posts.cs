using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PersonalProject.Domain.Entities
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public ICollection<Comment>? Comments { get; } = new List<Comment>();
        internal string? _likes { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string[] Likes
        {
            get { return _likes == null ? null : JsonConvert.DeserializeObject<string[]>(_likes); }
            set { _likes = JsonConvert.SerializeObject(value); }
        }

    }
}