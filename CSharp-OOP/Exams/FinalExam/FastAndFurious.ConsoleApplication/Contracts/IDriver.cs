﻿using System.Collections.Generic;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface IDriver : IIdentifiable
    {
        //int Id { get; }
        string Name { get; }
        GenderType Gender { get; }
        IMotorVehicle ActiveVehicle { get; }
        IEnumerable<IMotorVehicle> Vehicles { get; }
        void AddVehicle(IMotorVehicle vehicle);
        void SetActiveVehicle(IMotorVehicle vehicle);
        bool RemoveVehicle(IMotorVehicle vehicle);
    }
}
