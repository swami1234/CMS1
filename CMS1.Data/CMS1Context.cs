using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS1.Model;

namespace CMS1.Data
{
    public class CMS1Context : DbContext
    {
        public CMS1Context() : base("MVC_CMS") //CMS1 is name of connection string
        {

        }

        public DbSet<Sidebar> Sidebars { get; set; } //add namesapce cms1.model;
        public DbSet<Page> Pages { get; set; }
        public DbSet<RoleModal> Roles { get; set; }
        public DbSet<UserModal> Users { get; set; }
    }
}

       

