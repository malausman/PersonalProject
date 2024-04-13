using Microsoft.AspNetCore.Http;
using Services.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static PersonalProject.Utils.AppConstants;

namespace PersonalProject.Utils.ClaimManager
{
    public class ClaimsManager : IClaimsManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClaimsManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetClaimValue(string ClaimName)
        {
            if (_httpContextAccessor.HttpContext == null)
                return string.Empty;

            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var claim = claimsIdentity?.FindFirst(c => c.Type == ClaimName);
            if (claim != null)
            {
                return claim.Value;
            }
            return string.Empty;
        }

        public UserModel GetUserModel()
        {
            return new UserModel
            {
                userId = GetClaimValue(AppClaims.userId),
                userName = GetClaimValue(AppClaims.userName),
                role=int.Parse(GetClaimValue(ClaimTypes.Role)),
                RefreshTokenID = int.Parse(GetClaimValue(AppClaims.RefreshTokenID))
            };
        }
    }
}
