using ClientWebAPI.Constants;
using ClientWebAPI.Dto;
using System;
using System.Collections.Generic;

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
                    },
                    Uri = uri,
                }
            };
        }

        public static ActionResultDto GetErrorResponse(int errorCode, string uri, string parameterName)
        {
            return new ActionResultDto
            {
                Response = new ErrorResponse
                {
                    Error = new Error
                    {
                        Code = errorCode,
                        Message = string.Format(ErrorsDefinition.ErrorCodes[errorCode], parameterName)
                    },
                    Uri = uri
                }
            };
        }

        internal static string GetErrorResponse(object errorCodes)
        {
            throw new NotImplementedException();
        }
    }
}
