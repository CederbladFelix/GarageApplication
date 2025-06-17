using GarageApplication.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication.Garage
{
    public class Garage<T> : IEnumerable<T>, IGarage<T> where T : Vehicle
    {
        private T?[] _vehicles;
        public int Capacity { get; }

        private int _count;

        public bool isFull() => _count == Capacity;


        public Garage(int capacity)
        {
            _vehicles = new T[capacity];
            Capacity = capacity;
        }

        public bool ParkVehicle(T vehicle)
        {
            if (isFull())
                return false;

            if (_vehicles.Any(v => v?.RegistrationNumber == vehicle.RegistrationNumber))
                return false;


            for (int i = 0; i < _vehicles.Length; i++)
            {
                if (_vehicles[i] == null)
                {
                    _vehicles[i] = vehicle;
                    _count++;
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
                    _count--;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _vehicles)
            {
                if (item != null)
                    yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
