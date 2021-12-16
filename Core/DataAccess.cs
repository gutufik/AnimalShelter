using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Core
{
    public static class DataAccess
    {
        private static string ConnectionStr = ConfigurationManager.ConnectionStrings["AnimalDB"].ConnectionString;
        public static List<Animal> GetAnimals()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStr))
            {
                return connection.Query<Animal>("select * from Animal").AsList();
            }
        }
        public static List<Aviary> GetAviaries()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStr))
            {
                return connection.Query<Aviary>("select * from Aviary").AsList();
            }
        }
        public static List<Animal> GetAnimalsInAviary(int id)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStr))
            {
                return connection.Query<Animal>("select an.AnimalID, an.[Name] from [dbo].[Animal] an" +
                                                " join[dbo].[AviaryAnimal] aa " +
                                                "on aa.AnimalID = an.AnimalID " +
                                                "join [dbo].[Aviary] av " +
                                                "on aa.AviaryID = av.AviaryID " +
                                                $"where av.AviaryID = {id}").AsList();
            }
        }
        public static List<Food> GetFood()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStr))
            {
                return connection.Query<Food>("select * from Food").AsList();
            }
        }
    }
}
