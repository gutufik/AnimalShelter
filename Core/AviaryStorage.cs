using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;

namespace Core
{
    public static class AviaryStorage
    {
        public static List<Aviary> Aviaries { get; set; } = GetAviaries();

        public static void AddAviary()
        {
            DataAccess.AddAviary();
            Aviaries = GetAviaries();   
        }
        public static void RemoveAviary(int aviaryID)
        {
            DataAccess.RemoveAviary(aviaryID);
        }
        public static List<Animal> GetAnimals()
        {
            return DataAccess.GetAnimals();
        }
        public static void DeleteAnimal(int animalID)
        {
            DataAccess.DeleteAnimal(animalID);
        }
        public static int RemoveAnimalFromAviary(int animalID)
        {
            return DataAccess.RemoveAnimalFromAviary(animalID);
        }
        public static Animal GetAnimal(int animalID)
        {
            return DataAccess.GetAnimal(animalID);
        }
        public static List<Aviary> GetAviaries()
        {
            return DataAccess.GetAviaries();
        }
        public static void AddAnimal(Animal animal)
        {
            DataAccess.AddAnimal(animal);        
        }
        public static void UpdateAnimal(int animalID, Animal animal)
        {
            DataAccess.UpdateAnimal(animalID, animal);
        }
        public static List<Animal> GetHomelessAnimals()
        {
            return DataAccess.GetHomelessAnimals();
        }
        public static void AddAnimalToAviary(int aviaryID, int animalID)
        {
            var model = new AviaryModel() 
            {
                aviary = new Aviary() {AviaryID = aviaryID }, 
                animal = new Animal() {AnimalID = animalID } 
            };
            DataAccess.AddAnimalToAviary(model);
        }
        public static List<Animal> GetAnimalsInAviary(int aviaryId)
        {
            return DataAccess.GetAnimalsInAviary(aviaryId);
        }
    }
}
