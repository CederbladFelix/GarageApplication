using GarageApplication.Vehicles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GarageApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<UI>();
                    services.AddSingleton<Manager>();
                })
                .UseConsoleLifetime()
                .Build();
            host.Services.GetRequiredService<Manager>().Application();


        }
    }
}
