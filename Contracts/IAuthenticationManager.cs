using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAuthenticationManager
    {
        bool Authenticate(string username, string password);
    }
}
