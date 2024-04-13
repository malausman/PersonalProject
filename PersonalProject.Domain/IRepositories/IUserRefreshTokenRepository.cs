using PersonalProject.Domain.Entities;
using PersonalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Domain.Repositories
{
    public interface IUserRefreshTokenRepository : IRepository<UserRefreshToken>
    {
        Task<UserRefreshToken> GetUserRefreshToken(string UserId,int RefreshTokenID);
        Task<bool> IsUserRefreshTokenExist(string UserId);
    }
}
