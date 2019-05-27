using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Dto
{
    public class SuccessResponse<T> : BaseResponse
    {
        public IEnumerable<T> Result { get; set; }
        public override string Message => "Data fetched successfully";
        public override int Status => 0;
    }
}
