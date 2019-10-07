using CMS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Data.Interfaces
{
    public interface IPageRepository : IRepository<Page>
    {
        Page GetPageBySlug(string slug);
        bool SlugExists(string slug);
        bool SlugExists(int id, string slug);

        List<Page> GetPageMenu();
        List<Page> GetPagesWithSidebar();
    }
}
