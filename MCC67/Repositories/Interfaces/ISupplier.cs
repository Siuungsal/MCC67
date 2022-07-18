using MCC67.Models;
using System.Collections.Generic;

namespace MCC67.Repositories.Interfaces
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
