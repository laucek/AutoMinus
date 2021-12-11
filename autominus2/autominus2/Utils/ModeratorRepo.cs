using autominus2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace autominus2.Utils
{
    public class ModeratorRepo
    {
        public List<User> getUsers()
        {
            List<User> users = new List<User>();
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from Naudotojas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                users.Add(new User
                {
                    Id = Convert.ToInt32(item["id"]),
                    Name = Convert.ToString(item["vardas"]),
                    LastName = Convert.ToString(item["pavarde"]),
                    UserName = Convert.ToString(item["slapyvardis"]),
                    Email = Convert.ToString(item["el_pastas"]),
                    City = Convert.ToString(item["miestas"]),
                    BirthDate = Convert.ToDateTime(item["gimimo_metai"]),
                    RoleLevel = Convert.ToInt32(item["tipas"]),
                    Balance = Convert.ToSingle(item["balansas"]),
                    PhoneNumber = Convert.ToString(item["telefono_numeris"]),
                    Restrictions = Convert.ToInt32(item["galimybes"])
                });
            }
            return users;
        }
        public User getUser(int id)
        {
            User user = new User();
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from Naudotojas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                user.Id = Convert.ToInt32(item["id"]);
                user.Name = Convert.ToString(item["vardas"]);
                user.UserName = Convert.ToString(item["slapyvardis"]);
                user.Password = Convert.ToString(item["slaptazodis"]);
                user.LastName = Convert.ToString(item["pavarde"]);
                user.Email = Convert.ToString(item["el_pastas"]);
                user.BirthDate = Convert.ToDateTime(item["gimimo_metai"]);
                user.City = Convert.ToString(item["miestas"]);
                user.Balance = Convert.ToSingle(item["balansas"]);
                user.PhoneNumber = Convert.ToString(item["telefono_numeris"]);
                user.Restrictions = Convert.ToInt32(item["galimybes"]);
                user.RoleLevel = Convert.ToInt32(item["tipas"]);
            }
            return user;
        }
        public bool updateUser(User user)
        {
                string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE Naudotojas a SET a.vardas=?var, a.el_pastas=?el, a.tipas=?tip, a.galimybes=?gal WHERE a.id=?idas";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?idas", MySqlDbType.Int32).Value = user.Id;
                mySqlCommand.Parameters.Add("?var", MySqlDbType.VarChar).Value = user.Name;
                mySqlCommand.Parameters.Add("?el", MySqlDbType.VarChar).Value = user.Email;
                mySqlCommand.Parameters.Add("?tip", MySqlDbType.Int32).Value = user.RoleLevel;
                mySqlCommand.Parameters.Add("?gal", MySqlDbType.Int32).Value = user.Restrictions;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
        }


        public void deleteUser(int id)
        {
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM Naudotojas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}