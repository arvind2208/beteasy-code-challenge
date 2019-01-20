using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Renderers;
using dotnet_code_challenge.Repositories;
using dotnet_code_challenge.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new DataSet());
            services.AddTransient<IFileSystem, FileSystem>();
            services.AddTransient<IRepository<Horse>, HorseRepository>();
            services.AddTransient<IService<IEnumerable<Horse>>, GetHorsesByPriceService>();
            services.AddTransient<IRenderer<IEnumerable<Horse>>, HorsesByPriceRenderer>();
            services.AddTransient<IWriter, ConsoleWriter>();
        }
    }
}
