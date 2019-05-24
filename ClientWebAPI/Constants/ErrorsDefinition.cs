using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebAPI.Constants
{
    public static class ErrorsDefinition
    {
        public static readonly int PermissionDenied = 999;
        public static readonly int ParameterNotSpecified = 998;
        public static readonly int WrongParamaterValue = 997;

        public static readonly Dictionary<int, string> ErrorCodes
            = new Dictionary<int, string>
            {
                {PermissionDenied, "Permission Denied" },
                {ParameterNotSpecified, "No <{0}> parameter specified" },
                {WrongParamaterValue, "Wrong value given for <{0}> parameter" }
            };
    }
}
