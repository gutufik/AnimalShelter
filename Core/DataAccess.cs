using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Core.ViewModels;

namespace Core
{
    public static class DataAccess
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["AnimalDB"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);
        public static List<Animal> GetAnimals()
        {
            return connection.Query<Animal>("select * from Animal").AsList();
        }
        public static List<Aviary> GetAviaries()
        {
            return connection.Query<Aviary>("select * from Aviary").AsList();
        }
        public static List<Animal> GetAnimalsInAviary(int id)
        {
            return connection.Query<Animal>("select an.AnimalID, an.[Name] from [dbo].[Animal] an" +
                                            " join[dbo].[AviaryAnimal] aa " +
                                            "on aa.AnimalID = an.AnimalID " +
                                            "join [dbo].[Aviary] av " +
                                            "on aa.AviaryID = av.AviaryID " +
                                            $"where av.AviaryID = {id}").AsList();
        }
        public static List<Food> GetFood()
        {
            return connection.Query<Food>("select * from Food").AsList();
        }
        public static bool IsLoginCorrect(LoginModel model)
        {
            return connection.Query<User>("SELECT * FROM [dbo].[User] u " +
                                            $"where u.[Email] = '{model.Email}'" +
                                            $"and u.[Password] = '{model.Password}'").AsList().Count > 0;
        }
        public static bool RegisterUser(RegisterModel model)
        {
            try
            {
                connection.Query($"insert into [dbo].[User] (Email, [Password]) " +
                    $"values('{model.Email}', '{model.Password}')");
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public static void DeleteAnimal(int id)
        {
            connection.Query($"delete from [dbo].[Animal] where [AnimalID] = {id}");
        }
    }
}
