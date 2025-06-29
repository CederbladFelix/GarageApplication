﻿using GarageApplication.Vehicles;

namespace GarageApplication.Garage
{
    public interface IGarage<T> : IEnumerable<T> where T : Vehicle
    {
        int Capacity { get; }

        bool isEmpty();
        bool isFull();
        bool ParkVehicle(T vehicle);
        bool UnparkVehicle(T vehicle);
    }
}