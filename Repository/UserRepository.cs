using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Linq;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }

        public User GetUserByUsername(string username)
        {
            return FindByCondition(user => user.Username.Equals(username))
                .DefaultIfEmpty(new User())
                .FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            Create(user);
        }
    }
}
