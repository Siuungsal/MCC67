using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IProduk
    {
        List<Produk> Get();
        Produk Get(int id);
        int Post(Produk produk);
        int Put(Produk produk);
        int Delete(Produk produk);

    }
}
