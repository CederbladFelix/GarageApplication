using GarageApplication.Garage;
using GarageApplication.UserInterface;
using GarageApplication.Vehicles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GarageApplication.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string AppSettingsFileName = "appsettings.json";

            IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile(AppSettingsFileName, optional: false, reloadOnChange: true)
                                .Build();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IUI, UI>();
                    services.AddSingleton<IGarage<Vehicle>>(_ => new Garage<Vehicle>(config.GetValue<int>("garage:capacity")));
                    services.AddSingleton<IHandler, Handler>();
                    services.AddSingleton<IUIService, UIService>();
                    services.AddSingleton<Manager>();
                })
                .UseConsoleLifetime()
                .Build();
            host.Services.GetRequiredService<Manager>().Application();


        }
    }
}
