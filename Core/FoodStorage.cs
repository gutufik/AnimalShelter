using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;

namespace Core
{
    public static class FoodStorage
    {
        public static List<Food> Foods { get; set; } = GetFood();

        public static void AddDiet(FeedModel feed)
        {
            DataAccess.AddDiet(feed);
        }
        public static List<Food> GetFood()
        {
            return DataAccess.GetFood();
        }
        public static void AddFood(Food food)
        {
            DataAccess.AddFood(food);        
        }
        public static List<Diet> GetDiets(Animal animal)
        {
            return DataAccess.GetDiets(animal);
        }
    }
}
