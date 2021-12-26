using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AviaryController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Aviary> Get()
        {
            return AviaryStorage.GetAviaries();
        }
        [HttpGet("{id}")]
        public ActionResult<List<Animal>> Get(int id)
        {
            var result = AviaryStorage.GetAnimalsInAviary(id);
            if (result == null)
                return NotFound();

            return result;
        }
        [HttpPost]
        public IActionResult Create()
        {
            AviaryStorage.AddAviary();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AviaryStorage.RemoveAviary(id);
            return NoContent();
        }
    }
}
