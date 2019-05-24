using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ClientExtended : Client
    {
        public string ClientName { get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
