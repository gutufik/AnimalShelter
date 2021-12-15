﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace AnimalShelter.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            return View(DataAccess.GetFood());
        }
    }
}
