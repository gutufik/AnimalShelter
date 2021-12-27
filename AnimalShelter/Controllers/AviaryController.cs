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
                animals = AviaryStorage.GetAnimalsInAviary(aviaryID), //!!!!!!!!!!
                aviary = new Aviary { AviaryID = aviaryID }
            };
            return View(model);
        }
        public IActionResult AddAviary()
        {
            AviaryStorage.AddAviary(); //!!!!!!!!!!!!!!!!!!
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int animalID)
        {
            int aviaryID = AviaryStorage.RemoveAnimalFromAviary(animalID); 
            return RedirectToAction("Animals", new { aviaryID = aviaryID });
        }
        public IActionResult AddAnimal(int aviaryID)
        {
            var model = new AviaryModel();
            model.aviary = new Aviary() { AviaryID = aviaryID };
            model.animals = AviaryStorage.GetHomelessAnimals(); 
            
            return View(model);
        }
        [HttpPost]
        public IActionResult AddAnimal(AviaryModel model)
        {
            AviaryStorage.AddAnimalToAviary(model.aviary.AviaryID, model.animal.AnimalID); 
            return RedirectToAction("Animals", new { aviaryID = model.aviary.AviaryID });
        }
        public IActionResult RemoveAviary(int aviaryID)
        {
            AviaryStorage.RemoveAviary(aviaryID);
            return RedirectToAction("Index");
        }
    }
}
