using dotnet_code_challenge.AdapterProviderFactory;
using dotnet_code_challenge.Models;
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
            if (Directory.Exists(basePath))
            {
                foreach (string file in Directory.GetFiles(basePath))
                {
                    var adapter = (new FeedAdapterProviderFactory()).GetFeedAdapter(file);
                    adapter.FilePath = file;
                    adapter.Fill(dataSet);
                }
            }

            //Initialize repositories //TODO:

            //Get results by invoking GetHorsesByPrice Service
            var result = (new GetHorsesByPriceService()).Invoke();
            //Print the results
            Console.WriteLine("Results printed successfully");
        }
    }
}
