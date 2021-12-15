using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace AnimalShelter.Controllers
{
    public class AviaryController : Controller
    {
        public IActionResult Index()
        {
            return View(DataAccess.GetAviaries());
        }
        public IActionResult Animals(int id)
        {
            return View(DataAccess.GetAnimalsInAviary(id));
        }
    }
}
