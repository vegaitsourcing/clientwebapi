using ClientWebAPI.Dto;
using ClientWebAPI.Model.Errors;
using System.Collections.Generic;

namespace ClientWebAPI
{
    public static class ResponseHelper
    {
        public static CustomActionResult GetSuccessResponse<T>(IEnumerable<T> data, string uri)
        {
            return new CustomActionResult
            {
                Response = new SuccessResponse<T>
                {
                    Result = data,
                    Uri = uri
                }
            };
        }

        public static CustomActionResult GetSuccessResponse<T>(T data, string uri)
        {
            return new CustomActionResult
            {
                Response = new SuccessResponse<T>
                {
                    Result = new List<T> { data },
                    Uri = uri
                }
            };
        }

        public static CustomActionResult GetErrorResponse(BaseError error, string uri)
        {
            return new CustomActionResult
            {
                Response = new ErrorResponse
                {
                    Error = new List<Error>
                    {
                        new Error
                        {
                            Code = error.Code,
                            Message = error.Message
                        }
                    },
                    Uri = uri,
                }
            };
        }

        public static CustomActionResult GetErrorResponse(BaseError error, string uri, string parameterName)
        {
            return new CustomActionResult
            {
                Response = new ErrorResponse
                {
                    Error = new List<Error>
                    {
                        new Error
                        {
                            Code = error.Code,
                            Message = error.Message
                        }
                    },
                    Uri = uri,
                }
            };
        }

    }
}
