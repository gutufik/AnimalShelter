using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.ViewModels;

namespace AnimalShelter.Controllers
{
    public class AviaryController : Controller
    {
        public IActionResult Index()
        {
            return View(AviaryStorage.Aviaries);
        }
        public IActionResult Animals(int aviaryID)
        {
            var model = new AviaryModel() 
            { 
                animals = DataAccess.GetAnimalsInAviary(aviaryID), //!!!!!!!!!!
                aviary = new Aviary { AviaryID = aviaryID }
            };
            return View(model);
        }
        public IActionResult AddAviary()
        {
            DataAccess.AddAviary(); //!!!!!!!!!!!!!!!!!!
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int animalID)
        {
            int aviaryID = DataAccess.RemoveAnimalFromAviary(animalID); //!!!!!!!!!!!!!!!
            return RedirectToAction("Animals", new { aviaryID = aviaryID });
        }
        public IActionResult AddAnimal(int aviaryID)
        {
            var model = new AviaryModel();
            model.aviary = new Aviary() { AviaryID = aviaryID };
            model.animals = DataAccess.GetHomelessAnimals(); //!!!!!!!!!!!!!!!!!!!
            
            return View(model);
        }
        [HttpPost]
        public IActionResult AddAnimal(AviaryModel model)
        {
            DataAccess.AddAnimalToAviary(model); //!!!!!!!!!!!!!!!!!!!!!
            return RedirectToAction("Animals", new { aviaryID = model.aviary.AviaryID });
        }
        public IActionResult RemoveAviary(int aviaryID)
        {
            AviaryStorage.RemoveAviary(aviaryID);
            return RedirectToAction("Index");
        }
    }
}
