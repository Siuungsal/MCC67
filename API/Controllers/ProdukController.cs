using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdukController : BaseController<Produk, ProdukRepository>
    {
        ProdukRepository tRepository;
        public ProdukController(ProdukRepository tRepository) : base(tRepository)
        {
            this.tRepository = tRepository;
        }

        /*[HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public new ActionResult<int> Get(int id)
        {
            var result = tRepository.Get(id);
            if (result == null)
            {
                return NotFound(new { status = 404, message = "Data could not be found" });
            }
            return Ok(new { status = 200, message = "Data has been retrieved", data = result });
        }*/
    }
}
