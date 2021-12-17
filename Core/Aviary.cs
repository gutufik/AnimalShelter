using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Aviary
    {
        public int AviaryID { get; set; }

        public string Name { get; set; }
        public static List<Animal> animals { get; private set; } = DataAccess.GetAnimals();

        public void AddAnimal(Animal animal)
        { }
        public void RemoveAnimal(Animal animal)
        { }
    }
}
