using MCC67.Models;
using System.Collections.Generic;

namespace MCC67.Repositories.Interfaces
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
