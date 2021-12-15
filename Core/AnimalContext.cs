using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Core
{
    class AnimalContext : DbContext
    {
        public AnimalContext() : base("BloggingCompactDatabase")
        { }
    }
}
