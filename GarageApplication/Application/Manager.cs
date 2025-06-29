﻿using GarageApplication.Garage;
using GarageApplication.UserInterface;
using GarageApplication.Vehicles;

namespace GarageApplication.Application
{
    public class Manager
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
            Handler.LoadGarage();

            if (!Handler.IsGarageEmpty())
            {
                Console.WriteLine("Garage loaded from file");
                return;
            }

            int capacity = Handler.GetCapacity();
            int numberOfCarsInGarage = UIService.GetValidInteger("How many cars are parked in the garage?\n" +
                                                                    $"The garages capacity is {capacity}");
            Console.WriteLine();

            if (numberOfCarsInGarage > Handler.GetCapacity())
                Console.WriteLine($"Can't add that many cars to the garage");

            else
            {
                for (int i = 0; i < numberOfCarsInGarage; i++)
                {
                    Vehicle vehicle = UI.CreateVehicle()!;
                    Handler.ParkVehicle(vehicle);

                }
            }

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
            Handler.SaveGarage();
            Console.WriteLine("The application is now closing");
        }

        private void ListParkedVehicles() => Handler.ListVehicles();

        private void NumberTheVehiclesOfAType() => Handler.PrintCountByVehicleType();


        private void AddOrRemoveVehicle()
        {

            VehicleAction vehicleAction = UI.GetAddOrRemoveVehicleChoice();

            if (vehicleAction == VehicleAction.Add)
            {
                Vehicle vehicle = UI.CreateVehicle()!;
                bool isParked = Handler.ParkVehicle(vehicle);
                if (isParked)
                    Console.WriteLine("The vehicle has been parked");
                else
                    Console.WriteLine("The vehicle could not be parked");
            }
            else
            {
                ListParkedVehicles();
                if (!Handler.IsGarageEmpty())
                {
                    string registrationNumber = UIService.GetValidRegistrationNumber();
                    Vehicle? vehicle = Handler.GetParkedVehicleByRegistration(registrationNumber);
                    if (vehicle != null)
                    {
                        bool isUnparked = Handler.UnparkVehicle(vehicle);

                        if (isUnparked)
                            Console.WriteLine("The vehicle has been removed");
                        else
                            Console.WriteLine("The vehicle could not be unparked");

                    }
                    else
                        Console.WriteLine("There is no parked car with that registration number");
                }


            }

        }

        private void ParkedByRegistration()
        {
            string registrationNumber = UIService.GetValidRegistrationNumber();
            Vehicle? vehicle = Handler.GetParkedVehicleByRegistration(registrationNumber);
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
