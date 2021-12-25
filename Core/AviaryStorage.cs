using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class AviaryStorage
    {
        public static List<Aviary> Aviaries { get; set; } = DataAccess.GetAviaries();

        public static void AddAviary() //!!!!!!!!!!!!!!
        {
            DataAccess.AddAviary();
            Aviaries = DataAccess.GetAviaries();
                
        }

        public static void RemoveAviary(int aviaryID) //!!!!!!!!!!!!
        {
            DataAccess.RemoveAviary(aviaryID);
        }

        public static List<Animal> GetAnimals()
        {
            var animals = new List<Animal>();
            foreach (Aviary av in Aviaries)
            {
                av.FillAviary();
                foreach (var an in av.GetAnimals())
                {
                    animals.Add(an);
                }
            }
            return animals;
        }
        public static void DeleteAnimal(int animalId)
        {
            DataAccess.DeleteAnimal(animalId);
        }
        public static int RemoveAnimalFromAviary(int animalID)
        {
            return DataAccess.RemoveAnimalFromAviary(animalID);
        }

    }
}
