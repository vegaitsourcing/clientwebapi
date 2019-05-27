using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Model.Errors
{
    public class WrongParameterValueError : BaseError
    {
        private string _parameterName;

        public override int Code => 997; 
        public override string Message => $"Wrong value given for {_parameterName} parameter";

        public WrongParameterValueError(string parameterName)
        {
            _parameterName = parameterName;
        }
       
    }
}
