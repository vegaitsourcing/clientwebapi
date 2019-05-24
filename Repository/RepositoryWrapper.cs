using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IClientRepository _client;

        public IClientRepository Client
        {
            get
            {
                if(_client == null)
                {
                    _client = new ClientRepository(_repoContext);
                }

                return _client;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
