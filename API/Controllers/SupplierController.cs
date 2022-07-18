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
    [Authorize(Roles = "Member")]
    //[Authorize]
    public class SupplierController : BaseController<Supplier, SupplierRepository>
    {
        public SupplierController(SupplierRepository tRepository) : base(tRepository)
        {
        }

    }
}
