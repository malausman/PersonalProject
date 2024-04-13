using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Utils.ClaimManager
{
    public interface IClaimsManager
    {
        public string GetClaimValue(string claimName);
        public UserModel GetUserModel();
    }
}
