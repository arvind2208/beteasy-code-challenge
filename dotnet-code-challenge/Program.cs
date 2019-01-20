using dotnet_code_challenge.AdapterProviderFactory;
using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Renderers;
using dotnet_code_challenge.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = builder.Build();

            var serviceCollection = new ServiceCollection();
            Startup.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            DataSet dataSet = (DataSet)serviceProvider.GetService(typeof(DataSet));
            string basePath = config["BasePath"];
            var fileSystem = serviceProvider.GetService<IFileSystem>();

            //For all files, load them into a common domain model/DataSet
            //Adapter to load the model from different providers
            //A strategy to decide which adapter to use for each of the backend services
            if (Directory.Exists(basePath))
            {
                foreach (string file in Directory.GetFiles(basePath))
                {
                    var adapter = (new FeedAdapterProviderFactory(fileSystem)).GetFeedAdapter(file);

                    adapter.Fill(file, dataSet);
                }
            }

            //Get results by invoking GetHorsesByPrice Service
            var horses = serviceProvider.GetService<IService<IEnumerable<Horse>>>().Invoke();
            
            //Print the results
            serviceProvider.GetService<IRenderer<IEnumerable<Horse>>>().Render(horses);
        }
    }
}
