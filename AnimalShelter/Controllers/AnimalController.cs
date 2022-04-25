using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;


namespace AnimalShelter.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View(DataAccess.GetAnimals());
        }
        public IActionResult Remove(int id)
        {
            var animal = DataAccess.GetAnimal(id);
            DataAccess.DeleteAnimal(animal);
            return RedirectToAction("Index", DataAccess.GetAnimals());
        }
        public IActionResult Feed(int id)
        {
            //var feedModel = new FeedModel()
            //{
            //    animal = AviaryStorage.GetAnimal(id),
            //    foods = FoodStorage.Foods
            //};
            return View();
        }
        [HttpPost]
        public IActionResult Feed()
        {
            //FoodStorage.AddDiet(feed);
            return RedirectToAction("Index", DataAccess.GetAnimals());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            DataAccess.SaveAnimal(animal);
            return RedirectToAction("Index", DataAccess.GetAnimals());
        }
    }
}
