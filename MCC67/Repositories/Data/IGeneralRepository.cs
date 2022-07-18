using System.Collections.Generic;

namespace MCC67.Repositories.Data
{
    public interface IGeneralRepository<TModel, TPrimaryKey>
        where TModel : class
    {
        List<TModel> Get();
        TModel Get(TPrimaryKey id);
        int Post(TModel model);
        int Put(TModel model);
        int Delete(TModel model);
    }
}
