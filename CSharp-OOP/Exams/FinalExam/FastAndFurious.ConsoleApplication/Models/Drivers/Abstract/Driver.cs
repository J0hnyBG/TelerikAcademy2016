using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Extensions;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Drivers.Abstract
{
    public abstract class Driver : Identifiable, IDriver
    {
        protected Driver(string name, GenderType gender) 
            : base()
        {
            this.Name = name;
            this.Gender = gender;
            this.Vehicles = new List<IMotorVehicle>();
        }
        public IMotorVehicle ActiveVehicle { get; private set; }

        public GenderType Gender { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<IMotorVehicle> Vehicles { get; private set; }

        public void AddVehicle(IMotorVehicle vehicle)
        {
            //TODO:
            Validator.CheckIfObjectsIsNull(vehicle, GlobalConstants.CannotSetNullObjectAsActiveVehicleExceptionMessage);

            if ( this.Vehicles.Contains(vehicle))
            {
                throw new InvalidOperationException(GlobalConstants.DriverCannotBeAssignedAsOwnerToVehicleMoreThanOnceExceptionMessage);
            }
            this.Vehicles = Vehicles.Concat(new List<IMotorVehicle> {vehicle});
        }
        public bool RemoveVehicle(IMotorVehicle vehicle)
        {
            //TODO:
            Validator.CheckIfObjectsIsNull(vehicle, GlobalConstants.CannotSetNullObjectAsActiveVehicleExceptionMessage);

            if ( this.Vehicles.Contains(vehicle))
            {
                this.Vehicles = this.Vehicles.Except(new List<IMotorVehicle> {vehicle});
                return true;
            }
            return false;

        }
        public void SetActiveVehicle(IMotorVehicle vehicle)
        {
            Validator.CheckIfObjectsIsNull(vehicle, GlobalConstants.CannotSetNullObjectAsActiveVehicleExceptionMessage);

            if (this.Vehicles.Contains(vehicle))
            {
                this.ActiveVehicle = vehicle;

            }
            else
            {
                throw new InvalidOperationException(GlobalConstants.CannotSetForeignVehicleAsActiveExceptionMessage);
            }
        }
    }
}
