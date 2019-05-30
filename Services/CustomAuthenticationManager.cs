using Contracts;
using Entities.Extensions;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class CustomAuthenticationManager : IAuthenticationManager
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CustomAuthenticationManager(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public bool Authenticate(string username, string password)
        {
            var user = _repositoryWrapper.User.GetUserByUsername(username);
            if (user.IsEmptyObject())
            {
                return false;
            }
            return user.HashedPassword.Equals(GenerateHashedPassword(password, user.Salt));
        }

        private string GenerateHashedPassword(string password, string salt)
        {
            using (HMAC hmac = HMAC.Create("HmacSHA256"))
            {
                hmac.Key = Encoding.UTF8.GetBytes(salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return Convert.ToBase64String(hmac.Hash);
            }
        }       
    }
}
