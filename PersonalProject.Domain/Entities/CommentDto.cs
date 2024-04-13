using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PersonalProject.Domain.Entities
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Message { get; set; }
        public bool IsLike { get; set; } // If Comment.Likes contains specific UserId return true, else return false
        public string FirstName { get; set; } // Get the FirstName from the UsersTable where UserId = Users.UserId
        public string Picture { get; set; } // Get the Picture from the UsersTable where UserId = Users.UserId

    }
}