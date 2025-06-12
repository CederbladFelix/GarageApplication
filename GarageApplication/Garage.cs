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
        private T[] _vehicles;

        public Garage(int capacity)
        {
            _vehicles = new T[capacity];
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            
        }

        public void ExitVehicle(Vehicle vehicle)
        {

        }

        public string GetVehicles()
        {
            return "";
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
