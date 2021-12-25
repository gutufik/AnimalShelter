using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;

namespace Core
{
    public class Aviary
    {
        public int AviaryID { get; set; }
        public string Name { get; set; }
        public static List<Animal> Animals { get; private set; }

        public void FillAviary() //!!!!!!!!!!
        {
            Animals = DataAccess.GetAnimalsInAviary(AviaryID);
        }
        public void AddAnimal(Animal animal)
        {
            var model = new AviaryModel() { animal = animal, aviary = this };
            DataAccess.AddAnimalToAviary(model);
        }
        public void RemoveAnimal(Animal animal)
        {
            DataAccess.RemoveAnimalFromAviary(animal.AnimalID);        
        }
        public List<Animal> GetAnimals()
        {
            return Animals;
        }
    }
}
