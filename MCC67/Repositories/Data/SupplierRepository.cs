using MCC67.Context;
using MCC67.Models;
using MCC67.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MCC67.Repositories.Data
{
    //public class SupplierRepository : ISupplier
    public class SupplierRepository : GenericRepository<Supplier, int>
    {
        public SupplierRepository(MyContext myContext) : base(myContext) 
        {

        }
        /*MyContext myContext;
        public SupplierRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public List<Supplier> Get()
        {
            var supplier = myContext.Supplier.ToList();
            return supplier;
        }

        public Supplier Get(int id)
        {
            var supplier = myContext.Supplier.Find(id);
            return supplier;
        }

        public int Post(Supplier supplier)
        {
            myContext.Supplier.Add(supplier);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Supplier supplier)
        {
            myContext.Entry(supplier).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }

        public int Delete(Supplier supplier)
        {
            myContext.Entry(supplier).State = EntityState.Deleted;
            var result = myContext.SaveChanges();
            return result;
        }*/

    }
}
