using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Dto
{
    public class ErrorResponse : Response
    {
        public override string Message => "Error in fetching data";
        public override int Status => 1;
        public Error Error { get; set; }
    }
}
