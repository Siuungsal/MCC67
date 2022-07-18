using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class ProdukRepository : GenericRepository<Produk>
    {
        public ProdukRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
