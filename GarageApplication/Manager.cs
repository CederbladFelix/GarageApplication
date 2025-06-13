using GarageApplication.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal class Manager
    {
        public Handler? Handler { get; set; }
        public UI UI { get; set; }
        public Manager(UI ui)
        {
            UI = ui;
        }
        public void Application()
        {
            Initialize();
            Run();
            Shutdown();

        }
        private void Initialize()
        {
            int garageSize = UI.AskForGarageSize();
            Vehicle[]? vehicles = UI.AskForAlreadyParkedVehicles();
            Handler = new Handler(garageSize);
        }
        private void Run()
        {
            //GetMainMenu();
        }

        private void Shutdown()
        {
            throw new NotImplementedException();
        }
    }
}
