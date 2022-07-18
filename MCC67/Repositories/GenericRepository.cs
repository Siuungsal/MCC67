using MCC67.Context;
using MCC67.Repositories.Data;
using System.Collections.Generic;
using System.Linq;

namespace MCC67.Repositories
{
    public class GenericRepository<TModel, TPrimaryKey> : IGeneralRepository<TModel, TPrimaryKey>
        where TModel : class
    {
        MyContext myContext;

        public GenericRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(TModel model)
        {
            myContext.Set<TModel>().Remove(model);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<TModel> Get()
        {
            var data = myContext.Set<TModel>().ToList();
            return data;
        }

        public TModel Get(TPrimaryKey id)
        {
            var data = myContext.Set<TModel>().Find(id);
            return data;
        }

        public int Post(TModel model)
        {
            myContext.Set<TModel>().Add(model);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(TModel model)
        {
            myContext.Set<TModel>().Update(model);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
