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

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IUI, UI>();
                    services.AddSingleton<IGarage<Vehicle>>(provider => new Garage<Vehicle>(10));
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
