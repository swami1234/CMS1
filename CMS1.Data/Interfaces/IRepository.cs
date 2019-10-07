using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Data.Interfaces
{
   public  interface IRepository <TModel> where TModel : class //making it generic, t denotes type

    {
        void Create(TModel entity);
        void Update(TModel entity);

        List<TModel> GetAll();

        TModel GetById(object id);

        void Delete(TModel entity);
        void DeleteById(object id);

    }
}
