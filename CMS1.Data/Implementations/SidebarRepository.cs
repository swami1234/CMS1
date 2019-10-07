using CMS1.Data.Interfaces;
using CMS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Data.Implementations
{
   public  class SidebarRepository : Repository<Sidebar>,ISideBarRepository
    {

        public SidebarRepository(CMS1Context context) :base(context)
        {
                
        }
    }
}
