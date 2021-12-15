using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess.GetAnimals();
            Console.WriteLine("Hello World!");
        }
    }
    public class Animal
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
    }
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

    public class Food
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
    }

    public class User
    {
        int ID;
        string Name;
        string Login;
        string Password;
    }

}
