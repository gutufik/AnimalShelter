using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.ViewModels;

namespace AnimalShelter.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View(AviaryStorage.GetAnimals());
        }
        public IActionResult Remove(int id)
        {
            AviaryStorage.DeleteAnimal(id);
            return RedirectToAction("Index", AviaryStorage.GetAnimals());
        }
        public IActionResult Feed(int id)
        {
            var feedModel = new FeedModel()
            {
                animal = DataAccess.GetAnimal(id),
                foods = DataAccess.GetFood()
            };
            return View(feedModel);
        }
        [HttpPost]
        public IActionResult Feed(FeedModel feed)
        {
            DataAccess.AddDiet(feed);
            return RedirectToAction("Index", AviaryStorage.GetAnimals());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            DataAccess.AddAnimal(animal);
            return RedirectToAction("Index", AviaryStorage.GetAnimals());
        }
    }
}
