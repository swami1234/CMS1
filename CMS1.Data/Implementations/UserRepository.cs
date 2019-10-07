using CMS1.Data.Interfaces;
using CMS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Data.Implementations
{
    public class UserRepository : Repository <UserModal>,IUserRepository
    {


        private readonly CMS1Context _context;


        public UserRepository(CMS1Context context) : base(context)
        {
            _context = context;
        }

        //public void Create(UserModal entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(UserModal entity)
        //{
        //    throw new NotImplementedException();
        //}

        public UserModal GetUserWithRoles(string Username)
        {
            return _context.Users.Include("Roles").Where(x => x.UserName == Username).FirstOrDefault();
        }

        //public void Update(UserModal entity)
        //{
        //    throw new NotImplementedException();
        //}

        public bool UserExists(string username)
        {
            return _context.Users.Any(x => x.UserName == username);
        }

        List<UserModal> IRepository<UserModal>.GetAll()
        {
            throw new NotImplementedException();
        }

        UserModal IRepository<UserModal>.GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
