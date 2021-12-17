using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class FeedModel
    {
        public Animal animal { get; set; }
        public List<Food> foods { get; set; }
        public Diet diet { get; set; }
    }
}
