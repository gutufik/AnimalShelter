using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers // можно лучше: лишние комментарии
    // хорошо: код самокомментируемый 
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        // GET: api/<FoodController>
        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return FoodStorage.GetFood();
        }
        // POST api/<FoodController>
        [HttpPost]
        public IActionResult Post([FromBody] Food food)
        {
            FoodStorage.AddFood(food);
            return NoContent();
        }
    }
}
