using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Servisi.IServisi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinestar_WEB_API.Controllers
{
    [ApiController]
    public class BaseController<db_type,view_type> : Controller
    {
        private readonly IBaseService<db_type, view_type> service;

        public BaseController(IBaseService<db_type, view_type> service)
        {
            this.service = service;
        }

        
        [HttpGet]
        public virtual ActionResult<IEnumerable<db_type>> GetAll()//[FromQuery] TSearch q)
        {
            var result = service.GetAll();
            if(result!=null)
                return Ok(result);

            return BadRequest("Somthing went wrong!");
        }

        [HttpGet("{id}")]
        public virtual ActionResult<db_type> GetByID(int id)
        {
            var result = service.GetById(id);
            if (result != null)
                return Ok(result);

            return BadRequest("Somthing went wrong!");

        }

        [HttpPut("{id}")]
        public virtual ActionResult<db_type> Update(int id,[FromBody] db_type entity)
        {
            var result = service.Update(id, entity);
            if (result != null)
                return Ok(result);

            return BadRequest("Somthing went wrong!");

        }

        [HttpPost]
        public virtual ActionResult<db_type> Insert([FromBody] db_type entity)
        {

            var result = service.Insert(entity);
            if (result != null)
                return Ok(result);

            return BadRequest("Somthing went wrong!");
        }

        [HttpDelete("{id}")]
        public virtual ActionResult<db_type> Delete(int id)
        {
            var result = service.Delete(id);
            if (result != null)
                return Ok(result);

            return BadRequest("Somthing went wrong!");
        }
    }
}
