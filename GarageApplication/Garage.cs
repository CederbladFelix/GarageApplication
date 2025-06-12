using GarageApplication.VehicleTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T?[] _vehicles;

        public Garage(int capacity)
        {
            _vehicles = new T[capacity];
        }

        public bool ParkVehicle(T vehicle)
        {
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
                if (_vehicles[i] != null && _vehicles[i]!.Equals(vehicle))
                {
                    _vehicles[i] = null;
                    return true;
                }
            }
            return false; 
        }


        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicles
                .Where(v => v != null)
                .Select(v => v.Clone());
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _vehicles)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
