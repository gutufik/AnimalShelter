using System;
using Core;
using Core.ViewModels;

namespace ConsoleInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var command = Console.ReadLine();
                if (command.Trim().ToLower() == "exit")
                    return;
                Execute(command);
            }
        }
        private static void Execute(string command)
        {
            var arguments = command.Trim().Split();
            switch (arguments[0])
            {
                case "add":
                    Add(arguments);
                    break;
                case "get":
                    Get(arguments);
                    break;
                case "update":
                    Update(arguments);
                    break;
                case "remove":
                    Remove(arguments);
                    break;
                default:
                    Console.WriteLine($"Unknown command");
                    break;
            }
        
        }
        private static void Add(string[] args)
        {
            switch (args[1])
            {
                case "diet":
                    FoodStorage.AddDiet
                    (
                        new FeedModel()
                        {
                            diet = new Diet
                            {
                                AnimalID = int.Parse(args[2]),
                                FoodID = int.Parse(args[3]),
                                Weight = int.Parse(args[4])
                            }
                        }
                    );
                    break;
                case "animal":
                    AviaryStorage.AddAnimal(new Animal() { Name = args[2] });
                    break;
                case "food":
                    FoodStorage.AddFood
                    (
                        new Food()
                        {
                            FoodName = args[2],
                            Weight = int.Parse(args[3])
                        }
                    );
                    break;
                case "aviary":
                    AviaryStorage.AddAviary();
                    break;
                case "animaltoaviary":
                    AviaryStorage.AddAnimalToAviary(int.Parse(args[2]),
                                                    int.Parse(args[3]));
                    break;
                default:
                    Console.WriteLine($"Unknown command");
                    break;
            }
        }
        private static void Get(string[] args)
        {
            switch (args[1])
            {
                case "animals":
                    foreach (var a in AviaryStorage.GetAnimals())
                        Console.WriteLine($"{a.AnimalID} {a.Name}");
                    break;
                case "aviaries":
                    foreach (var a in AviaryStorage.Aviaries)
                        Console.WriteLine($"{a.AviaryID} {a.Name}");
                    break;
                case "animalsinaviary":
                    foreach (var a in AviaryStorage.GetAnimalsInAviary(int.Parse(args[2])))
                        Console.WriteLine($"{a.AnimalID} {a.Name}");
                    break;
                case "food":
                    foreach (var f in FoodStorage.GetFoods())
                        Console.WriteLine($"{f.FoodID} {f.FoodName} {f.Weight}");
                    break;
                case "animal":
                    Console.WriteLine(AviaryStorage.GetAnimal(int.Parse(args[2])).Name);
                    break;
                case "homelessanimals":
                    foreach (var a in AviaryStorage.GetHomelessAnimals())
                        Console.WriteLine($"{a.AnimalID} {a.Name}");
                    break;
                case "diets":
                    foreach (var d in FoodStorage.GetDiets(new Animal()
                    {
                        AnimalID = int.Parse(args[2])
                    }))
                        Console.WriteLine($"{d.AnimalID} {d.Date} {d.FoodID} {d.Weight}");
                    break;
                default:
                    Console.WriteLine($"Unknown command");
                    break;
            }
        }
        private static void Remove(string[] args)
        {
            switch (args[1])
            {
                case "animal":
                    AviaryStorage.DeleteAnimal(int.Parse(args[2]));
                    break;
                case "animalfromaviary":
                    AviaryStorage.RemoveAnimalFromAviary(int.Parse(args[2]));
                    break;
                case "aviary":
                    AviaryStorage.RemoveAviary(int.Parse(args[2]));
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
        private static void Update(string[] args)
        {
            switch (args[1])
            {
                case "animal":
                    AviaryStorage.UpdateAnimal(int.Parse(args[2]), new Animal() { Name = args[3] });
                    break;
            }
        }

    }
}
