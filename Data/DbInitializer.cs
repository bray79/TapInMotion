using System;
using System.Linq;
using TapInMotion.Models;

namespace TapInMotion.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.School.Any())
            {
                return; // Returns if any school already exists. ie. db is seeded
            }
   
            foreach (var s in context.School.ToList())
            {
                context.School.Remove(s);
            }
            context.SaveChanges();
            foreach (var s in context.Station.ToList())
            {
                context.Station.Remove(s);
            }
            context.SaveChanges();

            var unf = new School
            {
                Name = "University of North Florida",
                Alias = "unf",
                Longitude = (decimal)-81.50851,
                Latitude = (decimal)30.27132,
                MapZoom = 14,
                City = "Jacksonville",
                State = "Florida"
            };
            context.School.Add(unf);
            context.SaveChanges();
            var stations = new Station[]
            {
                new Station
                {
                    SchoolID = unf.SchoolID,
                    Name = "Delaney Student Union Station",
                    Latitude = (decimal)30.276615,
                    Longitude = (decimal)-81.509589,
                    BikeCapacity = 20,
                    SkateboardCapacity = 15,
                    ScooterCapacity = 10
                },
                new Station
                {
                    SchoolID = unf.SchoolID,
                    Name = "Lot 18 Station",
                    Latitude = (decimal)30.27146,
                    Longitude = (decimal)-81.50896,
                    BikeCapacity = 10,
                    SkateboardCapacity = 10,
                    ScooterCapacity = 10
                },
                new Station
                {
                    SchoolID = unf.SchoolID,
                    Name = "Library Station",
                    Latitude = (decimal)30.26960,
                    Longitude = (decimal)-81.50804,
                    BikeCapacity = 20,
                    SkateboardCapacity = 30,
                    ScooterCapacity = 30
                },
                new Station
                {
                    SchoolID = unf.SchoolID,
                    Name = "Osprey Landing Station",
                    Latitude = (decimal)30.265656,
                    Longitude = (decimal)-81.505613,
                    BikeCapacity = 25,
                    SkateboardCapacity = 15,
                    ScooterCapacity = 20
                },
                new Station
                {
                    SchoolID = unf.SchoolID,
                    Name = "Osprey Fountain Station",
                    Latitude = (decimal)30.26678,
                    Longitude = (decimal)-81.50229,
                    BikeCapacity = 25,
                    SkateboardCapacity = 20,
                    ScooterCapacity = 20
                }
            };
            foreach (Station s in stations)
            {
                context.Station.Add(s);
            }
            context.SaveChanges();
            var vehicles = new Vehicle[]
            {
                new Vehicle
                {
                    SchoolID = unf.SchoolID,
                    Type = VehicleType.Skateboard,
                    CurrentStationID = stations[0].StationID,
                },
                new Vehicle
                {
                    SchoolID = unf.SchoolID,
                    Type = VehicleType.Skateboard,
                    CurrentStationID = stations[0].StationID,
                },
                new Vehicle
                {
                    SchoolID = unf.SchoolID,
                    Type = VehicleType.Skateboard,
                    CurrentStationID = stations[1].StationID,
                },
                new Vehicle
                {
                    SchoolID = unf.SchoolID,
                    Type = VehicleType.Skateboard,
                    CurrentStationID = stations[1].StationID,
                },
                new Vehicle
                {
                    SchoolID = unf.SchoolID,
                    Type = VehicleType.Bicycle,
                    CurrentStationID = stations[0].StationID,
                },
                new Vehicle
                {
                    SchoolID = unf.SchoolID,
                    Type = VehicleType.Scooter,
                    CurrentStationID = stations[0].StationID,
                }
            };
            foreach (Vehicle v in vehicles)
            {
                context.Vehicle.Add(v);
            }
            context.SaveChanges();
        }
    }
}