using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Utils
{
    [Serializable]

    public class AppserviceException:Exception
    {
        public int ErrorCode { get; set; }
        public AppserviceException() { }
        public AppserviceException(string message,int errorCode=(int)HttpStatusCode.BadRequest):base(message) 
        {
            this.ErrorCode = errorCode;
        }
    }
}
