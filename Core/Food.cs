using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Food // можно лучше: сделать приватными set которые не должны торсать наружу 
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int Weight { get; set; }
    }
}
