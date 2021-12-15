using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Core
{
    public static class Helper
    {
        public static string GetConStr(string name)
        {
            
            var strings = ConfigurationManager.ConnectionStrings;
            var output = strings[name].ConnectionString;
            return output;
        }
    }
}
