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
        private readonly IHandler Handler;
        private readonly IUIService UIService;
        private readonly IUI UI;
        public Manager(IUI ui, IHandler handler, IUIService uIService)
        {
            UI = ui;
            Handler = handler;
            UIService = uIService;
        }
        public void Application()
        {
            Initialize();
            Run();
            Shutdown();

        }
        private void Initialize()
        {

        }
        private void Run()
        {
            bool running = true;
            while (running)
            {
                UI.PrintMainMenu();
                int answer = UIService.GetValidMenuChoice(6);

                switch (answer)
                {
                    case MainMenuChoice.Exit:
                        running = false;
                        break;
                    case MainMenuChoice.ListParkedVehicles:
                        Console.Clear();
                        ListParkedVehicles();
                        break;
                    case MainMenuChoice.NumberTheVehiclesOfAType:
                        Console.Clear();
                        NumberTheVehiclesOfAType();
                        break;
                    case MainMenuChoice.AddOrRemoveVehicle:
                        Console.Clear();
                        AddOrRemoveVehicle();
                        break;
                    case MainMenuChoice.ParkedByRegistration:
                        Console.Clear();
                        ParkedByRegistration();
                        break;
                    case MainMenuChoice.SearchByQuality:
                        Console.Clear();
                        SearchByQuality();
                        break;
                }
            }

        }
        private void Shutdown()
        {
            
        }

        private void ListParkedVehicles() => Handler.ListVehicles();

        private void NumberTheVehiclesOfAType() => Handler.PrintCountByVehicleType();


        private void AddOrRemoveVehicle()
        {
            var (vehicleAction, vehicle) = UI.AddOrRemoveCreatedVehicle();
            if (vehicleAction == VehicleAction.Add)
            {
                Handler!.ParkVehicle(vehicle);
            }
            else
            {
                Handler!.UnparkVehicle(vehicle);
            }

        }

        private void ParkedByRegistration()
        {
            string registrationNumber = UIService.GetValidRegistrationNumber();
            bool isParked = Handler.IsParkedVehicleByRegistration(registrationNumber);
            if (isParked)
            {
                UI.printVehicleIsNotInGarage();
            }
            else
            {
                UI.printVehicleIsInGarage();
            }
        }

        private void SearchByQuality()
        {
            var (vehicleType, vehicleColor, numberOfWheels) = UI.GetPropertiesToSearchBy();
            Handler.PrintVehiclesByProperty(vehicleType, vehicleColor, numberOfWheels);

        }

    }
}
