using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface ISupplier
    {
        List<Supplier> Get();
        Supplier Get(int id);
        int Post(Supplier supplier);
        int Put(Supplier supplier);
        int Delete(Supplier supplier);
    }
}
