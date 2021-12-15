using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Core
{
    public static class DataAccess
    {
        public static List<Animal> GetAnimals()
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConStr("AnimalDB")))
            {
                return connection.Query<Animal>("select * from Animal").AsList();
            }
        }
    }
}
