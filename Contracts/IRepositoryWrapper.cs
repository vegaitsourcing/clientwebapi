using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IClientRepository Client { get; }
        IUserRepository User { get; }
        void Save();
    }
}
