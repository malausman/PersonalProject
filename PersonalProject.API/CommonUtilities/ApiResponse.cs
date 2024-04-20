using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.CommonUtilities
{
    public static class ApiResponse
    {
        public static ApiResponseDTO Ok(dynamic response)
        {
            return new ApiResponseDTO
            {
                Response = response,
                IsSuccessful = true,
                StatusCode = (int)HttpStatusCode.OK,
                Message = response.ToString(),
                Timestamp = DateTime.Now
                
            };
        }
        public static ApiResponseDTO BadRequest(dynamic response)
        {
            return new ApiResponseDTO
            {
                Response = response,
                IsSuccessful = false,
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = response.ToString(),
                Timestamp = DateTime.Now
            };
        }
        public static ApiResponseDTO Unauthorized(dynamic response)
        {
            return new ApiResponseDTO
            {
                Response = response,
                IsSuccessful = false,
                StatusCode = (int)HttpStatusCode.Unauthorized,
                Message = response.ToString(),
                Timestamp = DateTime.Now
            };
        }
    }
}
