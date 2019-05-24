using ClientWebAPI.Constants;
using ClientWebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI
{
    public static class ResponseHelper
    {
        public static ActionResultDto GetSuccessResponse<T>(IEnumerable<T> data, string uri)
        {
            return new ActionResultDto
            {
                Response = new SuccessResponse<T>
                {
                    Result = data,
                    Uri = uri
                }
            };
        }

        public static ActionResultDto GetSuccessResponse<T>(T data, string uri)
        {
            return new ActionResultDto
            {
                Response = new SuccessResponse<T>
                {
                    Result = new List<T> { data },
                    Uri = uri
                }
            };
        }

        public static ActionResultDto GetErrorResponse(int errorCode, string uri)
        {
            return new ActionResultDto
            {
                Response = new ErrorResponse
                {
                    Error = new Error
                    {
                        Code = errorCode,
                        Message = ErrorsDefinition.ErrorCodes[errorCode]
                    }
                }
            };
        }
    }
}
