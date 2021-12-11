using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autominus2.Models
{
    public class Advertisement
    {
        public DateTime AdCreationDate { get; set; }
        public string FuelType { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public string EngineCapacity { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int DoorCount { get; set; }
        public DateTime ModelYear { get; set; }
        public float Price { get; set; }
        public int Drivetrain { get; set; }
        public string Power { get; set; }
        public string Damage { get; set; }
        public string Color { get; set; }
        public int SeatCount { get; set; }
        public string WheelPosition { get; set; }
        public string FirstRegistrationCountry { get; set; }
        public string Co2Emissions { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Gearbox { get; set; }
        public string BodyType { get; set; }

        public Advertisement(DateTime adCreationDate, string fuelType, int mileage, string vin, string engineCapacity,
            string model, string make, int doorCount, DateTime modelYear, float price, int drivetrain, string power, string damage,
            string color, int seatCount, string wheelPosition, string firstRegistrationCountry, string co2Emissions, string city,
            string country, string phoneNumber, string gearbox, string bodyType)
        {
            AdCreationDate = adCreationDate;
            FuelType = fuelType;
            Mileage = mileage;
            Vin = vin;
            EngineCapacity = engineCapacity;
            Model = model;
            Make = make;
            DoorCount = doorCount;
            ModelYear = modelYear;
            Price = price;
            Drivetrain = drivetrain;
            Power = power;
            Damage = damage;
            Color = color;
            SeatCount = seatCount;
            WheelPosition = wheelPosition;
            FirstRegistrationCountry = firstRegistrationCountry;
            Co2Emissions = co2Emissions;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
            Gearbox = gearbox;
            BodyType = bodyType;
        }
    }
}