using MCC67.Context;
using MCC67.Models;
using MCC67.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MCC67.Repositories.Data
{
    //public class ProdukRepository : IProduk
    public class ProdukRepository : GenericRepository<Produk, int>
    {
        public ProdukRepository(MyContext myContext) : base(myContext)
        {

        }

        /*MyContext myContext;
        public ProdukRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public List<Produk> Get()
        {
            var produk = myContext.Produk.ToList();
            return produk;
        }

        public Produk Get(int id)
        {
            var produk = myContext.Produk.Find(id);
            return produk;
        }

        public int Post(Produk produk)
        {
            myContext.Produk.Add(produk);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Produk produk)
        {
            myContext.Entry(produk).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }

        public int Delete(Produk produk)
        {
            myContext.Entry(produk).State = EntityState.Deleted;
            var result = myContext.SaveChanges();
            return result;
        }*/

    }
}
