using CMS1.Data.Interfaces;
using CMS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CMS1.Data.Implementations
{
    public class PageRepository : Repository<Page>, IPageRepository
    {

        private readonly CMS1Context _context;

        public PageRepository(CMS1Context context) : base(context)
        {
            _context = context;
        }


        //public void Create(Page entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Page entity)
        //{
        //    throw new NotImplementedException();
        //}

        public Page GetPageBySlug(string slug)
        {
            return _context.Pages.Where(x => x.Slug == slug).FirstOrDefault();
        }

        public List<Page> GetPageMenu()
        {
            return _context.Pages.Where(x => x.IsVisibleInMenu).ToList();
        }

        public List<Page> GetPagesWithSidebar()
        {
            return _context.Pages.Include("Sidebar").ToList();
        }

        public bool SlugExists(string slug)
        {
            return _context.Pages.Include("Sidebar").Any(x => x.Slug == slug);
        }

        public bool SlugExists(int id, string slug)
        {
            return _context.Pages.Where(x => x.Id != id).Any(x => x.Slug == slug);
        }

        //public void Update(Page entity)
        //{
        //    throw new NotImplementedException();
        //}

        //List<Page> IRepository<Page>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //Page IRepository<Page>.GetById(object id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
