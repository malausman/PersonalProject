using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Utils
{
    public static class AppServicesResponse
    {
        public static ApiResponseDto OkResponse(dynamic response)
        {
            return new ApiResponseDto
            {
                Response = response,
                IsSuccessful = true,
                StatusCode = (int)HttpStatusCode.OK,
            };
        }
        public static ApiResponseDto BadRequest(dynamic response)
        {
            return new ApiResponseDto
            {
                Response = response,
                IsSuccessful = false,
                StatusCode = (int)HttpStatusCode.BadRequest,
            };
        }
        public static ApiResponseDto UnauthorizedResponse(dynamic response)
        {
            return new ApiResponseDto
            {
                Response = response,
                IsSuccessful = false,
                StatusCode = (int)HttpStatusCode.Unauthorized,
            };
        }
    }
}
