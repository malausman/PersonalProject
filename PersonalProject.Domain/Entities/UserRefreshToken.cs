using PersonalProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Domain.Entities
{
    public class UserRefreshToken
    {
        public  int Id { get; set; }
        public string UserId { get; set; }
        public  userInfo User { get; set; }
        public string Token { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }

    }
}
