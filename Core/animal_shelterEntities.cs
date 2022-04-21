using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public partial class animal_shelterEntities
    {
        private static animal_shelterEntities _context;

        public static animal_shelterEntities GetContext()
        {
            if (_context == null)
                _context  = new animal_shelterEntities();
            return _context;
        }
    }
}
