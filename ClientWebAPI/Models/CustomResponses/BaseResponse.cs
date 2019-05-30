using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Dto
{
    public abstract class BaseResponse
    {
        public abstract string Message { get; set; }
        public abstract int Status { get; }
        public string Uri { get; set; }
    }
}
