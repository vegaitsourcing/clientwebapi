using ClientWebAPI.Dto;
using ClientWebAPI.Model.Errors;
using System.Collections.Generic;

namespace ClientWebAPI
{
    public static class ResponseHelper
    {
        public static CustomActionResult GetSuccessResponse<T>(IEnumerable<T> data, string uri, string message)
        {
            return new CustomActionResult
            {
                Response = new SuccessResponse<T>
                {
                    Result = data,
                    Uri = uri,
                    Message = message
                }
            };
        }

        public static CustomActionResult GetSuccessResponse<T>(T data, string uri, string message)
        {
            return new CustomActionResult
            {
                Response = new SuccessResponse<T>
                {
                    Result = new List<T> { data },
                    Uri = uri,
                    Message = message,
                }
            };
        }

        public static CustomActionResult GetErrorResponse(BaseError error, string uri, string message)
        {
            return new CustomActionResult
            {
                Response = new ErrorResponse
                {
                    Errors = new List<BaseError> { error },
                    Uri = uri,
                    Message = message,
                }
            };
        }

        public static CustomActionResult GetErrorResponse(IEnumerable<BaseError> errors, string uri, string message)
        {
            return new CustomActionResult
            {
                Response = new ErrorResponse
                {
                    Errors = errors,
                    Uri = uri,
                    Message = message,
                }
            };
        }

    }
}
