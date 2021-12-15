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
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
