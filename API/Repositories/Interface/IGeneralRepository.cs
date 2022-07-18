using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IGeneralRepository<TModel>
        where TModel : class
    {
        List<TModel> Get();
        TModel Get(int id);
        int Post(TModel model);
        int Put(TModel model);
        int Delete(TModel model);
    }
}
