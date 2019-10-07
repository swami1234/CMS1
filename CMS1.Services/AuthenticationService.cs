using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS1.Data.Interfaces;
using CMS1.Model;

namespace CMS1.Services
{
    public class AuthenticationService : IAuthenticationService
    {



        private readonly IUnitOfWork _uow;

        public AuthenticationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserModal Login (string userName, string password)
        {
            var userData = _uow.UserRepository.GetUserWithRoles(userName);

            if (userData == null)
                return null;

            bool hashStatus = BCrypt.Net.BCrypt.Verify(password, userData.Password);

            if (hashStatus)
            {
                UserModal user = new UserModal()
                {
                    id = userData.id,
                    UserName = userData.UserName,
                    Email = userData.Email,
                    Roles = userData.Roles

                };
                return user;
            }
            return null;
        }

        public bool Register(string email, string userName, string password)
        {
            bool userExists = _uow.UserRepository.UserExists(userName);

            if (!userExists)
            {
                UserModal newUser = new UserModal()
                {
                    Email = email,
                    UserName = userName,
                    Password = BCrypt.Net.BCrypt.HashPassword(password)
                };

                _uow.UserRepository.Create(newUser);
                _uow.Commit();

                return true;
            }
            return false;
        }
     
    }
}
