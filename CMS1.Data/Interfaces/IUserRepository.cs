using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS1.Model;
using CMS1.Data.Interfaces;

namespace CMS1.Data.Interfaces
{
   public interface IUserRepository : IRepository<UserModal>
    {
        UserModal GetUserWithRoles(string username);

        bool UserExists(string username);

    }
}
