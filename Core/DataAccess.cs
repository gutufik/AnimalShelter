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
        public static Animal GetAnimal(int id)
        {
            try
            {
                return connection.Query<Animal>($"select * from [dbo].[Animal]" +
                $" where [AnimalID] = {id}").AsList()[0];
            }
            catch { return null; }
            
        }
        public static void AddDiet(FeedModel model)
        {
            connection.Query("insert into [dbo].[Diet] " +
                            "([AnimalID],[Date],[FoodID],[Weight]) " +
                            $"values ({model.diet.AnimalID},'{DateTime.Now}',{model.diet.FoodID},{model.diet.Weight})");
        }
        public static void AddAnimal(Animal a)
        {
            connection.Query($"insert into [dbo].[Animal] ([Name]) values ('{a.Name}')");
        }
        public static void UpdateAnimal(int id,Animal a)
        {
            connection.Query($"update [dbo].[Animal] set [Name] = '{a.Name}' where [AnimalID] = {id}");
        }
        public static void AddFood(Food food) 
        {
            connection.Query($"insert into [dbo].[Food]" +
                            $"([FoodName], [Weight])" +
                            $"values ('{food.FoodName}',{food.Weight})");
        }
        public static int RemoveAnimalFromAviary(int animalID)
        {
            int aviaryID = connection.Query<int>("select [AviaryID] from [dbo].[AviaryAnimal] " +
                                                    $"where[AnimalID] = {animalID}").AsList()[0];
            connection.Query("delete from [dbo].[AviaryAnimal] " +
                                $"where [AnimalID] = {animalID}");
            return aviaryID;
        }
        public static void AddAviary()
        {
            connection.Query("insert into [dbo].[Aviary] ([Name]) values ('')");
        }
        public static void AddAnimalToAviary(AviaryModel model)
        {
            connection.Query("insert into [dbo].[AviaryAnimal] ([AviaryID], [AnimalID]) " +
                             $"values({model.aviary.AviaryID},{model.animal.AnimalID})");
        }
        public static List<Animal> GetHomelessAnimals()
        {
            return connection.Query<Animal>($"select a.[AnimalID], a.[Name] from [dbo].[Animal] a" +
                                            $" full join [dbo].[AviaryAnimal] aa " +
                                            $"on a.[AnimalID] = aa.[AnimalID] " +
                                            $"where aa.[AnimalID] is null").AsList();
        }
    }
}
