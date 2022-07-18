using API.Context;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TRepository> : ControllerBase
        where TModel : class
        where TRepository : IGeneralRepository<TModel>
    {

        TRepository tRepository;

        public BaseController(TRepository tRepository)
        {
            this.tRepository = tRepository;
        }

        [HttpDelete]
        public ActionResult<int> Delete(TModel model)
        {
            var result = tRepository.Delete(model);
            if(result == 0)
            {
                return NotFound(new {status = 404, message = "Data could not be found"});
            }
            return Ok(new {status = 200, message = "Data has been deleted"});
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult<List<TModel>> Get()
        {
            var result = tRepository.Get();
            if(result == null)
            {
                return NotFound(new {status = 404, message = "Data could not be found"});
            }
            return Ok(new {status = 200, message = "Data successfully retrieved", data = result});
        }

        [HttpGet("{id}")]
        public ActionResult<int> Get(int id)
        {
            var result = tRepository.Get(id);
            if(result == null)
            {
                return NotFound(new {status = 404, message = "Data could not be found"});
            }
            return Ok(new {status = 200, message = "Data has been retrieved", data = result});
        }

        [HttpPost]
        public ActionResult<int> Post(TModel model)
        {
            var result = tRepository.Post(model);
            if(result == 0)
            {
                return BadRequest(new {status = 400, message = "Bad Request, data could not be added"});
            }
            return Ok(new {status = 200, message = "Data has been added", data = result});
        }

        [HttpPut]
        public ActionResult<int> Put(TModel model)
        {
            var result = tRepository.Put(model);
            if(result == 0)
            {
                return NotFound(new {status = 404, message = "Data not found, data cannot be changed"});
            }
            return Ok(new {status = 200, message = "Data has been changed", data = result});
        }
    }
}
