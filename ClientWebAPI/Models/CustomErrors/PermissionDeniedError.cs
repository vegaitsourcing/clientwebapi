using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Model.Errors
{
    public class PermissionDeniedError : BaseError
    {
        public override int Code => 999;
        public override string Message => "Permission Denied";
    }
}
