using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Model.Errors
{
    public abstract class BaseError
    {
        public abstract int Code { get; }
        public abstract string Message { get; }

    }
}
