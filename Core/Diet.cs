using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Diet // можно лучше: сделать приватными set которые не должны торсать наружу 
    {
        public int AnimalID { get; set; }
        public DateTime Date { get; set; }
        public int FoodID { get; set; }
        public int Weight { get; set; }
    }
}
