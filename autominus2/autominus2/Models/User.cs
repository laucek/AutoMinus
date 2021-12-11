using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autominus2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoleLevel { get; set; }
        public float Balance { get; set; }
        public string PhoneNumber { get; set; }
        public int Restrictions { get; set; }

        public User(string name, string lastName, string userName, string password,
            string email, string city, DateTime birthDate, int roleLevel, float balance,
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