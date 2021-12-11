using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace autominus2.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("Vardas")]
        public string Name { get; set; }
        [DisplayName("Pavardė")]
        public string LastName { get; set; }
        [DisplayName("Slapyvardis")]
        public string UserName { get; set; }
        public string Password { get; set; }
        [DisplayName("El paštas")]
        public string Email { get; set; }
        [DisplayName("Miestas")]
        public string City { get; set; }
        [DisplayName("Gimimo data")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Rolė")]
        public int RoleLevel { get; set; }
        [DisplayName("Balansas")]
        public float Balance { get; set; }
        [DisplayName("Telefono numeris")]
        public double Balance { get; set; }
        public string PhoneNumber { get; set; }
        [DisplayName("Galimybės")]
        public int Restrictions { get; set; }

        public User()
        {
        }

        public User(string name, string lastName, string userName, string password,
            string email, string city, DateTime birthDate, int roleLevel, double balance,
            string phoneNumber, int restrictions, int id = -1)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
            City = city;
            BirthDate = birthDate;
            RoleLevel = roleLevel;
            Balance = balance;
            PhoneNumber = phoneNumber;
            Restrictions = restrictions;
        }
    }
}