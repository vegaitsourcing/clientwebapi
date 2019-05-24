using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Dto
{
    public abstract class Response
    {
        public string Uri { get; set; }
        public virtual string Message { get; set; }
        public virtual int Status { get; set; }
    }
}
