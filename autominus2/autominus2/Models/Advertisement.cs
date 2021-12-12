using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace autominus2.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        [DisplayName("Skelbimo kūrimo data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AdCreationDate { get; set; }
        [DisplayName("Kuro tipas")]
        public string FuelType { get; set; }
        [DisplayName("Rida")]
        public int Mileage { get; set; }
        [DisplayName("Kėbulo kodas")]
        public string Vin { get; set; }
        [DisplayName("Variklio tūris")]
        public string EngineCapacity { get; set; }
        [DisplayName("Modelis")]
        public string Model { get; set; }
        [DisplayName("Markė")]
        public string Make { get; set; }
        [DisplayName("Durų kiekis")]
        public int DoorCount { get; set; }
        [DisplayName("Pagaminimo data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime ModelYear { get; set; }
        [DisplayName("Kaina")]
        public float Price { get; set; }
        [DisplayName("Varantieji ratai")]
        public int Drivetrain { get; set; }
        [DisplayName("Galia")]
        public string Power { get; set; }
        [DisplayName("Defektai")]
        public string Damage { get; set; }
        [DisplayName("Spalva")]
        public string Color { get; set; }
        [DisplayName("Sėdimos vietos")]
        public int SeatCount { get; set; }
        [DisplayName("Vairo padėtis")]
        public string WheelPosition { get; set; }
        [DisplayName("Pirmoji registracija")]
        public string FirstRegistrationCountry { get; set; }
        [DisplayName("CO2 emisija")]
        public string Co2Emissions { get; set; }
        [DisplayName("Miestas")]
        public string City { get; set; }
        [DisplayName("Šalis")]
        public string Country { get; set; }
        [DisplayName("Telefono numeris")]
        public string PhoneNumber { get; set; }
        [DisplayName("Pavarų dėžė")]
        public string Gearbox { get; set; }
        [DisplayName("Kėbulo tipas")]
        public string BodyType { get; set; }
        public int FkId { get; set; }

        public Advertisement()
        {

        }
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
        public Advertisement(DateTime adCreationDate, string fuelType, int mileage, string vin, string engineCapacity,
            string model, string make, int doorCount, DateTime modelYear, float price, int drivetrain, string power, string damage,
            string color, int seatCount, string wheelPosition, string firstRegistrationCountry, string co2Emissions, string city,
            string country, string phoneNumber, string gearbox, string bodyType, int fkid, int id)
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
            FkId = fkid;
            Id = id;
        }
    }
}