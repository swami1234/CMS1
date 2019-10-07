using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Data.Interfaces
{
   public interface IUnitOfWork
    {
        ISideBarRepository SideBarRepository { get; }
        IPageRepository PageRepository { get; }
        IUserRepository UserRepository { get; }

        void Commit();
    }
}
