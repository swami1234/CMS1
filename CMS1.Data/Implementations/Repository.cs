using CMS1.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Data.Implementations
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : class
    {

        private readonly CMS1Context _context;

        public Repository(CMS1Context context)
        {
            _context = context;
        }

        public void Create(TModel entity)
        {
            _context.Set<TModel>().Add(entity);
        }

        public void Delete(TModel entity)
        {
            _context.Set<TModel>().Remove(entity);
        }

        public void DeleteById(object id)
        {
            TModel model = GetById(id);

            if(model!= null)
            {
                Delete(model);
            }
        }

        public List<TModel> GetAll()
        {
            return _context.Set<TModel>().ToList();
        }

        public TModel GetById(object id)
        {
            return _context.Set<TModel>().Find(id);
        }

        public void Update(TModel entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
