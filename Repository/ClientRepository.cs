using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }

        public IEnumerable<Client> GetAllClients()
        {
            return FindAll()
                .ToList();
        }

        public Client GetClientById(Guid clientId)
        {
            return FindByCondition(client => client.Id.Equals(clientId))
                .FirstOrDefault();
        }
    }
}
