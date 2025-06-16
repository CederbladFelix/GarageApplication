using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Vehicles
{
    internal abstract class Vehicle : IVehicle
    {
        private static HashSet<string> _usedRegistrationNumbers = new();
        private static readonly Random _random = new();

        public string RegistrationNumber { get; }
        public int NumberOfWheels { get; }
        public VehicleType Type { get; }
        public VehicleColor Color { get; }

        protected Vehicle(VehicleColor color, int numberOfWheels)
        {
            RegistrationNumber = GenerateUniqueRegistrationNumber();
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        private static string GenerateUniqueRegistrationNumber()
        {
            string registrationNumber;
            do
            {
                registrationNumber = GenerateRandomRegNumber();
            }
            while (!_usedRegistrationNumbers.Add(registrationNumber));
            return registrationNumber;
        }

        private static string GenerateRandomRegNumber()
        {
            var letters = new string(Enumerable.Range(0, 3)
                .Select(_ => (char)_random.Next('A', 'Z' + 1))
                .ToArray());

            var numbers = _random.Next(0, 1000).ToString("D3");

            return letters + numbers;
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Registration number: {RegistrationNumber}, Color: {Color}";
        }
    }

}
