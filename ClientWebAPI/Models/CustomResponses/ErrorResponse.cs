using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Dto
{
    public class ErrorResponse : BaseResponse
    {
        public override string Message => "Error in fetching data";
        public override int Status => 1;
        public IEnumerable<Error> Error { get; set; }
    }
}
