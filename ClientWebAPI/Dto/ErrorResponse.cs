using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Dto
{
    public class ErrorResponse : Response
    {
        public override string Message => "Data fetched successfully";
        public override int Status => 0;
        public Error Error { get; set; }
    }
}
