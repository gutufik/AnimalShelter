using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class AviaryModel // можно лучше: сделать приватными set которые не должны торсать наружу 
    {
        public Aviary aviary { get; set; }
        public List<Animal> animals{ get; set; }
        public Animal animal { get; set; }
    }
}
