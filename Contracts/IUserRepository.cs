using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        void CreateUser(User user);
        User GetUserByUsername(string username);
    }
}
