using CMS1.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CMS1Context _context;

        public UnitOfWork()
        {
            _context = new CMS1Context();

            SideBarRepository = new SidebarRepository(_context);
            UserRepository = new UserRepository(_context);
            PageRepository = new PageRepository(_context);

        }

        public ISideBarRepository SideBarRepository { get; }

        public IPageRepository PageRepository { get; }

        public IUserRepository UserRepository { get; }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
