using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Extensions;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Engine
{
    public class Engine
    {
        private readonly ICollection<IDriver> drivers;
        private readonly ICollection<IRaceTrack> raceTracks;
        private readonly ICollection<ITunningPart> tunningParts;
        private readonly ICollection<IMotorVehicle> motorVehicles;

        public Engine()
        {
            this.drivers = new List<IDriver>();
            this.raceTracks = new List<IRaceTrack>();
            this.tunningParts = new List<ITunningPart>();
            this.motorVehicles = new List<IMotorVehicle>();
        }

        public void Start()
        {
            var command = ReadCommand();
            var commandParameters = new string[] { string.Empty };

            while (command != GlobalConstants.ExitCommand)
            {
                commandParameters = ParseCommand(command);
                ExecuteCommand(commandParameters);
                command = ReadCommand();
            }
        }

        public string ReadCommand()
        {
            return Console.ReadLine();
        }
        public string[] ParseCommand(string command)
        {
            return command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }
        public void ExecuteCommand(string[] commandParameters)
        {
            // Choose strategy
            var commandType = commandParameters[0];
            switch (commandType)
            {
                case GlobalConstants.CreationStrategyCommand:
                    this.ExecuteCreationStrategy(commandParameters);
                    break;
                case GlobalConstants.RemovalStrategyCommand:
                    this.ExecuteRemovalStrategy(commandParameters);
                    break;
                case GlobalConstants.AssigningStrategyCommand:
                    this.ExecuteAssigningStrategy(commandParameters);
                    break;
                case GlobalConstants.SelectingStrategyCommand:
                    this.ExecuteSelectingStrategy(commandParameters);
                    break;
                case GlobalConstants.RunningStrategyCommand:
                    this.ExecuteRunningStrategy(commandParameters);
                    break;
                case GlobalConstants.DisplayingStrategyCommand:
                    this.ExecuteDisplayingStrategy(commandParameters);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
        public void ExecuteCreationStrategy(string[] commandParameters)
        {
            var createTypeCommand = commandParameters[1];
            var typeName = commandParameters[2];

            switch (createTypeCommand)
            {
                case GlobalConstants.DriverCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, this.drivers);
                    break;
                case GlobalConstants.TrackCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, this.raceTracks);
                    break;
                case GlobalConstants.TunningCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, this.tunningParts);
                    break;
                case GlobalConstants.VehicleCommand:
                    this.CreateObjectOfTypeAndAssignToCollection(typeName, this.motorVehicles);
                    break;
                default:
                    throw new NotSupportedException(GlobalConstants.CreationalOperationNotSupportedExceptionMessage);
            }

            // Why not extract this string in a constant? You're allowed to do it.
            Console.WriteLine(String.Format("{0} - successfully created!", typeName));
        }
        public void ExecuteAssigningStrategy(string[] commandParameters)
        {
            // TODO: Implement (Extend functionality)

            var removeTypeCommand = commandParameters[1];
            var objectToAssignId = int.Parse(commandParameters[2]);
            var ownerToAssignToId = int.Parse(commandParameters[5]);

            switch (removeTypeCommand)
            {
                case GlobalConstants.TunningCommand:
                    {
                        var vehicleToAssignTo = this.motorVehicles.GetById(ownerToAssignToId);
                        var tunningToAssign = this.tunningParts.GetById(objectToAssignId);
                        vehicleToAssignTo.AddTunning(tunningToAssign);
                        break;
                    }
                case GlobalConstants.VehicleCommand:
                    {
                        var driverToAssignTo = this.drivers.GetById(ownerToAssignToId);
                        var vehicleToAssign = this.motorVehicles.GetById(objectToAssignId);
                        driverToAssignTo.AddVehicle(vehicleToAssign);
                        break;
                    }
                case GlobalConstants.DriverCommand:
                    {
                        var driverToAssignTo = this.drivers.GetById(objectToAssignId);
                        var raceTrackToAssignTo = this.raceTracks.GetById(ownerToAssignToId);
                        raceTrackToAssignTo.AddParticipant(driverToAssignTo);
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException(GlobalConstants.AssigningOperationNotSupportedExceptionMessage);
                    }
            }

            Console.WriteLine(
                String.Format(
                    GlobalConstants.ItemAssignedSuccessfullyMessage,
                    objectToAssignId, 
                    ownerToAssignToId));
        }
        public void ExecuteRemovalStrategy(string[] commandParameters)
        {
            // TODO: Implement (Extend functionality)

            var removeTypeCommand = commandParameters[1];
            var objectToRemoveId = int.Parse(commandParameters[2]);
            var ownerToRemoveFromId = int.Parse(commandParameters[5]);

            switch (removeTypeCommand)
            {
                case GlobalConstants.DriverCommand:
                    {
                        var raceTrackToRemoveFrom = this.raceTracks.GetById(ownerToRemoveFromId);
                        var driverToRemove = raceTrackToRemoveFrom.Participants.GetById(objectToRemoveId);
                        raceTrackToRemoveFrom.RemoveParticipant(driverToRemove);
                        break;
                    }
                case GlobalConstants.VehicleCommand:
                    {
                        var driverToRemoveFrom = this.drivers.GetById(ownerToRemoveFromId);
                        var vehicleToRemove = driverToRemoveFrom.Vehicles.GetById(objectToRemoveId);
                        driverToRemoveFrom.RemoveVehicle(vehicleToRemove);
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException(GlobalConstants.RemovalOperationNotSupportedExceptionMessage);
                    }
            }
        }
        public void ExecuteSelectingStrategy(string[] commandParameters)
        {
            var driverId = int.Parse(commandParameters[5]);
            var driver = this.drivers.GetById(driverId);
            var vehicleId = int.Parse(commandParameters[2]);
            var vehicle = driver.Vehicles.GetById(vehicleId);
            driver.SetActiveVehicle(vehicle);

            Console.WriteLine(
                String.Format(
                    GlobalConstants.DriverSelectsNewVehicleMessage, 
                    driver.Name,
                    driver.Gender == GenderType.Male? "his" : "her", 
                    vehicle.GetType().Name));
        }
        public void ExecuteRunningStrategy(string[] commandParameters)
        {
            var raceTrack = this.raceTracks.GetById(int.Parse(commandParameters[2]));
            raceTrack.RunRace();
        }
        public void ExecuteDisplayingStrategy(string[] commandParameters)
        {
            // TODO: Implement (Extend functionality)
            //-display best 2 times from -track 9
            var timesCount = int.Parse(commandParameters[2]);
            var trackId = int.Parse(commandParameters[6]);
            var track = this.raceTracks.GetById(trackId);
            List<TimeSpan> listOfTimeSpans = new List<TimeSpan>();

            foreach (var finishedRacesResult in track.FinishedRacesResults)
            {
                foreach (var result in finishedRacesResult)
                {
                    listOfTimeSpans.Add(result);
                }
            }

            var best = (from q in listOfTimeSpans
                orderby q.Seconds
                select q).Take(timesCount);
            Console.WriteLine(string.Format(GlobalConstants.DisplayBestNTimesEverMessage, timesCount, track.TrackName));
            foreach (var timeSpan in best)
            {
                Console.WriteLine(timeSpan);
            }
        }
        public void CreateObjectOfTypeAndAssignToCollection<T>(string typeName, ICollection<T> collection)
        {
            var typeToInstantiate = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x=>x.Name == typeName);
            var instanceOfType = (T)Activator.CreateInstance(typeToInstantiate);
            collection.Add(instanceOfType);
        }
    }
}
