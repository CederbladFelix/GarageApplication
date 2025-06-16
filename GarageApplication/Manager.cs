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
            Handler = new Handler(garageSize, vehicles);
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
                }
            }

        }
        private void Shutdown()
        {
            throw new NotImplementedException();
        }

        private void ListParkedVehicles() => UI.PrintVehiclesInGarage(Handler!.Garage);

        private void NumberTheVehiclesOfAType() => UI.PrintVehicleTypeAndCount(Handler!.GetCountByVehicleType());


        private void AddOrRemoveVehicle()
        {
            UI.PrintAddOrRemoveMenu();
            int answer = UIService.GetValidMenuChoice(2);
            Vehicle vehicle = UIService.CreateVehicle()!;
            if (answer == 1)
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
            Vehicle? vehicle = Handler!.GetVehicleByRegistration(registrationNumber);
            if (vehicle == null)
            {
                UI.printVehicleIsNotInGarage();
            }
            else
            {
                UI.printVehicleIsInGarage(vehicle);
            }
        }

        private void SearchByQuality()
        {
            var (vehicleType, vehicleColor, numberOfWheels) = UI.GetPropertiesToSearchBy();
            IEnumerable<Vehicle>? vehicleSequence = Handler!.GetVehiclesByProperty(vehicleType, vehicleColor, numberOfWheels);

            if (vehicleSequence == null)
            {
                UI.PrintNoVehiclesFoundByProperty();
            }
            else
            {
                UI.PrintVehiclesByProperty(vehicleSequence);
            }

        }

    }
}
