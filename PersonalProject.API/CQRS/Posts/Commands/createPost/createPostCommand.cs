using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using MediatR;
using Microsoft.Graph.Models;
using Newtonsoft.Json;
using PersonalProject.Domain.Entities;
using PersonalProject.Utilities;
using PersonalProject.Utils;

namespace PersonalProject.API.CQRS.User.Commands.createPost
{
    public class createPostCommand : IRequest<ApiResponseDto>
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public ICollection<Comment> Comments { get; } = new List<Comment>();
        internal string _likes { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string[] Likes
        {
            get { return _likes == null ? null : JsonConvert.DeserializeObject<string[]>(_likes); }
            set { _likes = JsonConvert.SerializeObject(value); }
        }

    }
}
