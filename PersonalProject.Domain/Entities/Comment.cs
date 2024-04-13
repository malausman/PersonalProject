using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PersonalProject.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public string Message { get; set; }
        public Posts Post { get; set; } = null!;
        internal string _likes { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string[] Likes
        {
            get { return _likes == null ? null : JsonConvert.DeserializeObject<string[]>(_likes); }
            set { _likes = JsonConvert.SerializeObject(value); }
        }

        
    }
}