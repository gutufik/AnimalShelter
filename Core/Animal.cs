﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using Core.ViewModels;

namespace Core
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public string Name { get; set; }
        public List<Diet> Diets { get; set; }
        public Animal()
        {
            Diets = FoodStorage.GetDiets(this);
        }
        public void AddDiet(FeedModel model)
        {
            FoodStorage.AddDiet(model);
        }

    }
}
