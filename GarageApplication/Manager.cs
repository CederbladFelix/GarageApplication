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
                    case MainMenuChoice.ListParkedVehicles:
                        ListParkedVehicles();
                        break;
                    case MainMenuChoice.NumberTheVehiclesOfAType:
                        NumberTheVehiclesOfAType();
                        break;
                    case MainMenuChoice.AddOrRemoveVehicle:
                        AddOrRemoveVehicle();
                        break;
                    case MainMenuChoice.ParkedByRegistration:
                        ParkedByRegistration();
                        break;
                    case MainMenuChoice.SearchByQuality:
                        SearchByQuality();
                        break;
                    case MainMenuChoice.Exit:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("You did not enter a valid menu choice.");
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

            VehicleAction vehicleAction = UI.GetAddOrRemoveVehicleChoice();

            if (vehicleAction == VehicleAction.Add)
            {
                Vehicle vehicle = UI.CreateVehicle()!;
                Handler.ParkVehicle(vehicle);
                Console.WriteLine("The vehicle has been parked");
            }
            else
            {
                ListParkedVehicles();
                if (!Handler.IsGarageEmpty())
                {
                    string registrationNumber = UIService.GetValidRegistrationNumber();
                    Vehicle? vehicle = Handler.IsParkedVehicleByRegistration(registrationNumber);
                    if (vehicle != null)
                    {
                        Handler.UnparkVehicle(vehicle);
                        Console.WriteLine("The vehicle has been removed");

                    }
                    else
                        Console.WriteLine("There is no parked car with that registration number");
                }


            }

        }

        private void ParkedByRegistration()
        {
            string registrationNumber = UIService.GetValidRegistrationNumber();
            Vehicle? vehicle = Handler.IsParkedVehicleByRegistration(registrationNumber);
            if (vehicle == null)
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
