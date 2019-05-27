using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Model.Errors
{
    public class NoParameterSpecifiedError : BaseError
    {
        private string _parameterName;

        public override int Code  => 998;
        public override string Message =>  $"No {_parameterName} parameter specified";

        public NoParameterSpecifiedError(string parameterName)
        {
            _parameterName = parameterName;
        }
       
    }
}
