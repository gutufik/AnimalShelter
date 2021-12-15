using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AnimalShelter.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
