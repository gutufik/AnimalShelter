using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using Core.ViewModels;

namespace Core
{
    public static class DataAccess // можно улучшить: решение запросами не оптимальный метод
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["AnimalDB"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);
        public static List<Animal> GetAnimals()
        {
            return connection.Query<Animal>("select Id, AnimalName from Animal").AsList();
        }
        public static List<Aviary> GetAviaries()
        {
            return connection.Query<Aviary>("select * from Aviary").AsList();
        }
        public static List<Animal> GetAnimalsInAviary(int aviaryId)
        {
            return connection.Query<Animal>("select an.Id, an.[AnimalName] from [dbo].[Animal] an" +
                                            " join[dbo].[AviaryAnimal] aa " +
                                            "on aa.AnimalID = an.Id " +
                                            "join [dbo].[Aviary] av " +
                                            "on aa.AviaryID = av.AviaryID " +
                                            $"where av.AviaryID = {aviaryId}").AsList();
        }
        public static List<Food> GetFood()
        {
            return connection.Query<Food>("select * from Food").AsList();
        }
        public static void DeleteAnimal(int id)
        {
            connection.Query($"delete from [dbo].[Animal] where [Id] = {id}");
        }
        public static Animal GetAnimal(int id)
        {
            try
            {
                return connection.Query<Animal>($"select * from [dbo].[Animal]" +
                $" where [Id] = {id}").AsList().FirstOrDefault();
            }
            catch { return null; }
            
        }
        public static bool CanFeed(FeedModel model)
        {
            return connection.Query<bool>($"select cast(case when [weight] > {model.diet.Weight} THEN 1 ELSE 0 END AS BIT) " +
                $"from Food where FoodID = {model.diet.FoodID}").AsList().FirstOrDefault();
        }
        public static void AddDiet(FeedModel model)
        {
            if (CanFeed(model))
                connection.Query("insert into [dbo].[Diet] " +
                            "([AnimalID],[Date],[FoodId],[Weight]) " +
                            $"values ({model.diet.AnimalID},'{DateTime.Now}',{model.diet.FoodID},{model.diet.Weight})");
        }
        public static void AddAnimal(Animal a)
        {
            connection.Query($"insert into [dbo].[Animal] ([Name]) values ('{a.Name}')");
        }
        public static void UpdateAnimal(int id,Animal a)
        {
            connection.Query($"update [dbo].[Animal] set [AnimalName] = '{a.Name}' where [AnimalID] = {id}");
        }
        public static void AddFood(Food food) 
        {
            if (food.Weight > 0)
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
        public static List<Diet> GetDiets(Animal animal)
        {
            return connection.Query<Diet>($"select * from Diet " +
                                          $"where AnimalID = {animal.AnimalID}").AsList();
        }
        public static void RemoveAviary(int aviaryID)
        {
            connection.Query($"delete[dbo].[Aviary] where [AviaryID] = {aviaryID}");
        }
    }
}
