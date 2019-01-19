using dotnet_code_challenge.AdapterProviderFactory;
using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Repositories;
using dotnet_code_challenge.Services;
using System;
using System.IO;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //For all files, load them into a common domain model/DataSet
            //Adapter to load the model from different providers
            //A strategy to decide which adapter to use for each of the backend services
            //TODO: make basePath configurable
            string basePath = @"C:\interview\beteasy-code-challenge\dotnet-code-challenge\FeedData\";
            var dataSet = new DataSet();
            var fileSystem = new FileSystem();

            if (Directory.Exists(basePath))
            {
                foreach (string file in Directory.GetFiles(basePath))
                {
                    var adapter = (new FeedAdapterProviderFactory(fileSystem)).GetFeedAdapter(file);

                    adapter.Fill(file, dataSet);
                }
            }

            //Initialize repositories //TODO:
            var horseRepository = new HorseRepository(dataSet);
            //Get results by invoking GetHorsesByPrice Service
            var horses = (new GetHorsesByPriceService(horseRepository)).Invoke();
            //Print the results

            Console.WriteLine("Horses by Price");
            Console.WriteLine(string.Empty);
            Console.WriteLine($"{"Horse".PadRight(20)} Price");
            Console.WriteLine("============================");

            foreach (var horse in horses)
            {
                Console.WriteLine($"{horse.Name.Trim().PadRight(20)} {horse.Price:C}");
            }
            Console.WriteLine("Results printed successfully");
        }
    }
}
