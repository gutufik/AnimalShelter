using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    public class AviaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
