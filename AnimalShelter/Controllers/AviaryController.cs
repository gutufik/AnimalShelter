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
        public IActionResult Animals(int aviaryID)
        {
            //var model = new AviaryModel() 
            //{ 
            //    animals = AviaryStorage.GetAnimalsInAviary(aviaryID), //!!!!!!!!!!
            //    aviary = new Aviary { AviaryID = aviaryID }
            //};
            var aviary = DataAccess.GetAviary(aviaryID);
            return View(aviary.Animals);
        }
        public IActionResult AddAviary()
        {
            var aviary = new Aviary();
            DataAccess.SaveAviary(aviary); //!!!!!!!!!!!!!!!!!!
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int animalID)
        {
            int aviaryID = DataAccess.DeleteAnimalFromAviary(animalID);
            //int aviaryID = AviaryStorage.RemoveAnimalFromAviary(animalID); 
            return RedirectToAction("Animals", new { aviaryID = aviaryID });
        }
        public IActionResult AddAnimal(int aviaryID)
        {
            //var model = new AviaryModel();
            //model.aviary = new Aviary() { AviaryID = aviaryID };
            //model.animals = AviaryStorage.GetHomelessAnimals(); 
            
            return View();
        }
        [HttpPost]
        public IActionResult AddAnimal()
        {
            //AviaryStorage.AddAnimalToAviary(model.aviary.AviaryID, model.animal.AnimalID); 
            return RedirectToAction("Animals");
        }
        public IActionResult RemoveAviary(int aviaryID)
        {
            DataAccess.DeleteAviary(aviaryID);
            return RedirectToAction("Index");
        }
    }
}
