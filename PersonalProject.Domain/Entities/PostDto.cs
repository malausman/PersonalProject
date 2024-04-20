using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PersonalProject.Domain.Entities
{
    public class PostDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public int Comments { get; set; } // Number of Comments for this Post (Count from Comments table where PostId = Id)
        public bool IsLike { get; set; } // If Post.Likes contains specific UserId return true, else return false
        public string FirstName { get; set; } // Get the FirstName from the UsersTable where UserId = Users.UserId
        public string Picture { get; set; } // Get the Picture from the UsersTable where UserId = Users.UserId
        public List<CommentDto> CommentsShort { get; set; } // Get the Top 5 Comments from the Comments table for this post
        public List<CommentDto> CommentsFull { get; set; } // Get all the Comments from the Comments table for this post


    }
}