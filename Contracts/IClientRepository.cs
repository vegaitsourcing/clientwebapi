using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(Guid id);
    }

    
}
