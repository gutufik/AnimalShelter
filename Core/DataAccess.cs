using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    using Context = animal_shelterEntities;
    public static class DataAccess
    {
        public static List<Animal> GetAnimals()
        {
            return Context.GetContext().Animals.ToList();
        }

        public static Animal GetAnimal(int id)
        {
            return GetAnimals().FirstOrDefault(a => a.Id == id);
        }

        public static void SaveAnimal(Animal animal)
        {
            if (GetAnimals().FirstOrDefault(a => a.Id == animal.Id) == null)
                Context.GetContext().Animals.Add(animal);

            Context.GetContext().SaveChanges();
        }

        public static void DeleteAnimal(Animal animal)
        {
            Context.GetContext().Animals.Remove(animal);

            Context.GetContext().SaveChanges();
        }

        public static List<Aviary> GetAviaries()
        {
            return Context.GetContext().Aviaries.ToList();
        }

        public static Aviary GetAviary(int id)
        {
            return GetAviaries().FirstOrDefault(a => a.Id == id);
        }

        public static void SaveAviary(Aviary aviary)
        {
            if (GetAviaries().FirstOrDefault(a => a.Id == aviary.Id) == null)
                Context.GetContext().Aviaries.Add(aviary);

            Context.GetContext().SaveChanges();
        }

        public static void DeleteAviary(Aviary aviary)
        {
            DeleteAviary(aviary.Id);
        }

        public static void DeleteAviary(int aviaryId)
        {
            Context.GetContext().Aviaries.Remove(GetAviary(aviaryId));
            Context.GetContext().SaveChanges();
        }

        public static List<Food> GetFoods()
        {
            return Context.GetContext().Foods.ToList();
        }

        public static void AddFood(Food food)
        {
            if (food.Weight <= 0)
                return;

            Context.GetContext().Foods.Add(food);
            Context.GetContext().SaveChanges();
        }

        public static bool CanFeed(Diet diet)
        {
            return diet.Food.Weight > diet.Weight;
        }

        public static List<Diet> GetDiets()
        {
            return Context.GetContext().Diets.ToList();
        }

        public static void SaveDiet(Diet diet)
        {
            diet.Date = DateTime.Now;
            if (CanFeed(diet))
                Context.GetContext().Diets.Add(diet);
            Context.GetContext().SaveChanges();
        }

        public static int DeleteAnimalFromAviary(int animalId)
        {
            Animal animal = GetAnimal(animalId);
            Aviary aviary = animal.Aviaries.FirstOrDefault();

            aviary.Animals.Remove(animal);

            Context.GetContext().SaveChanges();
            return aviary.Id;
        }
    }
}
