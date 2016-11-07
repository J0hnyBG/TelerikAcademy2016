using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

using CarsCodeFirst.Data;
using CarsCodeFirst.Data.Migrations;
using CarsCodeFirst.Models;

using Newtonsoft.Json;

using Car = CarsCodeFirst.Importer.Models.Car;

namespace CarsCodeFirst.Importer
{
    public class Startup
    {
        private static void Main()
        {
            ImportData();
        }

        private static void ImportData()
        {
            var cars = new List<Car>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbModel, Configuration>());

            var files = Directory.GetFiles(@"..\..\..\..\..\..\Data.Json.Files")
                                 .Where(file => file.EndsWith(".json"))
                                 .ToList();

            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                var carsInFile = JsonConvert.DeserializeObject<IEnumerable<Car>>(content);
                cars.AddRange(carsInFile);
                Console.WriteLine($"{file} read.");
            }

            var manufacturerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var cityNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var dealerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var car in cars)
            {
                manufacturerNames.Add(car.ManufacturerName);
                cityNames.Add(car.Dealer.City);
                dealerNames.Add(car.Dealer.Name);
            }

            var db = new CarsDbModel();
            db.Database.CreateIfNotExists();

            foreach (var cityName in cityNames)
            {
                db.Cities.AddOrUpdate(x => x.Name, new City() { Name = cityName });
            }

            db.SaveChanges();

            foreach (var manufacturerName in manufacturerNames)
            {
                db.Manufacturers.AddOrUpdate(m => m.Name, new Manufacturer() { Name = manufacturerName });
            }

            db.SaveChanges();

            foreach (var dealerName in dealerNames)
            {
                db.Dealers.AddOrUpdate(m => m.Name, new Dealer() { Name = dealerName });
            }

            db.SaveChanges();

            for (int i = 0; i < cars.Count; i++)
            {
                var car = cars[i];

                var carCity = db.Cities.FirstOrDefault(x => x.Name == car.Dealer.City);
                var carDealer = db.Dealers.FirstOrDefault(d => d.Name == car.Dealer.Name);
                var carManufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == car.ManufacturerName);
                if (carCity == null || carDealer == null || carManufacturer == null)
                {
                    throw new ArgumentNullException();
                }

                var carToInsert = new CarsCodeFirst.Models.Car
                                  {
                                      Dealer = carDealer,
                                      Manufacturer = carManufacturer,
                                      Model = car.Model,
                                      Price = car.Price,
                                      Year = (short)car.Year
                                  };

                if (carToInsert.Dealer.Cities.All(c => c.Name != carCity.Name))
                {
                    carCity.Dealers.Add(carToInsert.Dealer);
                }

                db.Cars.Add(carToInsert);

                if (i % 200 == 0)
                {
                    db.SaveChanges();
                }
            }

            db.SaveChanges();
            Console.WriteLine("Cars added.");
        }
    }
}
