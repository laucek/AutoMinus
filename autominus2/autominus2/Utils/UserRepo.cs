using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using autominus2.Utils;
using autominus2.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace autominus2.Utils
{
    public class UserRepo
    {
        public static bool UpdateCurrentUser()
        {
            try
            {
                User usr = OurSession.LoggedInUser;
                string sql = $"UPDATE Naudotojas a SET a.vardas='{usr.Name}', a.pavarde='{usr.LastName}', a.slapyvardis='{usr.UserName}', " +
                    $"a.slaptazodis='{usr.Password}', a.el_pastas='{usr.Email}', a.miestas='{usr.City}', a.telefono_numeris='{usr.PhoneNumber}'" +
                    $" WHERE a.id={usr.Id}";
                string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlConnection.Open();
                int temp = mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static User SelectUserByEmail(string email)
        {
            try
            {
                string sql = $"SELECT * FROM `Naudotojas` WHERE el_pastas='{email}'";
                string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlConnection.Open();
                MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
                DataTable dt = new DataTable();
                mda.Fill(dt);
                mySqlConnection.Close();

                return new User(Convert.ToString(dt.Rows[0]["vardas"]),
                                Convert.ToString(dt.Rows[0]["pavarde"]),
                                Convert.ToString(dt.Rows[0]["slapyvardis"]),
                                Convert.ToString(dt.Rows[0]["slaptazodis"]),
                                Convert.ToString(dt.Rows[0]["el_pastas"]),
                                Convert.ToString(dt.Rows[0]["miestas"]),
                                Convert.ToDateTime(dt.Rows[0]["gimimo_metai"]),
                                Convert.ToInt32(dt.Rows[0]["tipas"]),
                                Convert.ToInt32(dt.Rows[0]["balansas"]),
                                Convert.ToString(dt.Rows[0]["telefono_numeris"]),
                                Convert.ToInt32(dt.Rows[0]["galimybes"]),
                                Convert.ToInt32(dt.Rows[0]["id"]));
            }
            catch
            {
                return null;
            }
        }

        public static bool InsertUser(User user)
        {
            try
            {
                string sql = "INSERT INTO `Naudotojas`(`vardas`, `pavarde`, `slapyvardis`, `slaptazodis`, `el_pastas`," +
                " `miestas`, `gimimo_metai`, `tipas`, `balansas`, `telefono_numeris`, `galimybes`)" +
                $" VALUES ('{user.Name}', '{user.LastName}', '{user.UserName}', '{user.Password}'," +
                $" '{user.Email}', '{user.City}', NOW(), 0, 0, '{user.PhoneNumber}', 0)";

                string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlConnection.Open();
                int temp = mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CloseCurrentHelp()
        {
            try
            {
                User usr = OurSession.LoggedInUser;
                string sql = $"UPDATE Pagalbos_prasymas a SET a.atsakyta=1 WHERE a.id ={OurSession.helpIndex}";

                string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlConnection.Open();
                int temp = mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool InsertPayment(Payment p)
        {
            try
            {
                string sql = $"INSERT INTO Saskaitos_pildymas (suma, fk_Naudotojasid_Naudotojas)" +
                    $" VALUES ({p.Sum}, {OurSession.LoggedInUser.Id})";

                string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlConnection.Open();
                int temp = mySqlCommand.ExecuteNonQuery();
                OurSession.helpIndex = mySqlCommand.LastInsertedId;
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateUserBalance(double amount)
        {
            try
            {
                User usr = OurSession.LoggedInUser;
                string sql = $"UPDATE Naudotojas a SET a.balansas={usr.Balance + amount}"+
                    $" WHERE a.id={usr.Id}";
                string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlConnection.Open();
                int temp = mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool InsertHelpRequest(User user, string question)
        {
            try
            {
                string sql = $"INSERT INTO Pagalbos_prasymas (Klausimas, fk_Naudotojas, atsakyta)" +
                    $" VALUES ('{question}', {user.Id}, 0)";

                string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlConnection.Open();
                int temp = mySqlCommand.ExecuteNonQuery();
                OurSession.helpIndex = mySqlCommand.LastInsertedId;
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}