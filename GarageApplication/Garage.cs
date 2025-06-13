using GarageApplication.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T?[] _vehicles;
        public int Capacity => _vehicles.Length;


        public Garage(int capacity, T[]? vehicles = null)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than 0.");

            _vehicles = new T[capacity];

            if (vehicles != null)
            {
                if (vehicles.Length > capacity)
                    throw new ArgumentException("Provided vehicles exceed garage capacity.");

                for (int i = 0; i < vehicles.Length; i++)
                {
                    _vehicles[i] = vehicles[i];
                }
            }
        }

        public bool ParkVehicle(T vehicle)
        {
            if (_vehicles.Any(v => v?.RegistrationNumber == vehicle.RegistrationNumber))
                return false;


            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] == null)
                {
                    _vehicles[i] = vehicle;
                    return true;
                }
            }
            return false;
        }

        public bool UnparkVehicle(T vehicle)
        {
            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] is T parkedVehicle &&
                    parkedVehicle.RegistrationNumber == vehicle.RegistrationNumber)
                {
                    _vehicles[i] = null;
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Vehicle> GetParkedVehicles()
        {
            return _vehicles
                .OfType<T>()
                .Select(v => v.Clone());
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _vehicles)
            {
                if (item is T vehicle)
                    yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
