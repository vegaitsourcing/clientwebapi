using ClientWebAPI.Model.Errors;
using System.Collections.Generic;

namespace ClientWebAPI.Dto
{
    public class ErrorResponse : BaseResponse
    {
        public override string Message { get; set; }
        public IEnumerable<BaseError> Errors { get; set; }
        public override int Status => 1;
    }
}
