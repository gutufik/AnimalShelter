using Microsoft.AspNetCore.Http;
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
    public class AnimalController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return AviaryStorage.GetAnimals();
        }
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            var result = DataAccess.GetAnimal(id);
            if (result == null)
                return NotFound();

            return result;
        }
        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            DataAccess.AddAnimal(animal);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Animal animal)
        {
            var result = DataAccess.GetAnimal(id);
            if (result == null)
                return NotFound();

            DataAccess.UpdateAnimal(id, animal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = DataAccess.GetAnimal(id);
            if (result == null)
                return NotFound();

            DataAccess.DeleteAnimal(id);
            return NoContent();
        }
    }
}
