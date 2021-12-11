using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using autominus2.Models;
using MySql.Data.MySqlClient;

namespace autominus2.Utils
{
    public class CarsRepo
    {
        public static bool InsertAdvertisement(Advertisement ad)
        {
            try
            {
                string sql = "INSERT INTO `Skelbimas`(`skelbimo_sukurimo_data`, `kuro_tipas`, `rida`, `vin_kodas`, `darbinis_turis`," +
                " `modelis`, `marke`, `duru_skaicius`, `metai`, `kaina`, `varantieji_ratai`, `galia`, `defektai`, `spalva`," +
                " `sedimu_vietu_skaicius`, `vairo_padetis`, `pirmosios_registracijos_salis`, `co2_emisija`, `miestas`, `salis`, " +
                " `telefono_numeris`, `pavaru_deze`, `kebulo_tipas`, `fk_Naudotojasid_Naudotojas`)" +
                $" VALUES (NOW(), '{ad.FuelType}', '{ad.Mileage}', '{ad.Vin}', '{ad.EngineCapacity}', '{ad.Model}', '{ad.Make}', '{ad.DoorCount}'," +
                $" '{ad.ModelYear}', '{ad.Price}', '{ad.Drivetrain}', '{ad.Power}', '{ad.Damage}', '{ad.Color}'," +
                $" '{ad.SeatCount}', '{ad.WheelPosition}', '{ad.FirstRegistrationCountry}', '{ad.Co2Emissions}', '{ad.City}', '{ad.Country}'," +
                $" '{ad.PhoneNumber}', '{ad.Gearbox}', '{ad.BodyType}', {OurSession.LoggedInUser.Id})";

                string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
                mySqlConnection.Open();
                int temp = mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception exc)
            {
                exc.GetType().ToString();
                return false;
            }
        }

        public List<Advertisement> getAdvertisements()
        {
            List<Advertisement> advertisements = new List<Advertisement>();
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A; convert zero datetime=True";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from Skelbimas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                advertisements.Add(new Advertisement
                {
                    Make = Convert.ToString(item["marke"]),
                    Model = Convert.ToString(item["modelis"]),
                    EngineCapacity = Convert.ToString(item["darbinis_turis"]),
                    BodyType = Convert.ToString(item["kebulo_tipas"]),
                    Price = Convert.ToSingle(item["kaina"]),
                    Mileage = Convert.ToInt32(item["rida"])
                });
            }
            return advertisements;
        }

        public Advertisement getAdvertisement(int id)
        {
            Advertisement advertisement = new Advertisement();
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A; convert zero datetime=True";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from Skelbimas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                advertisement.Id = Convert.ToInt32(item["id"]);
                advertisement.AdCreationDate = Convert.ToDateTime(item["skelbimo_sukurimo_data"]);
                advertisement.FuelType = Convert.ToString(item["kuro_tipas"]);
                advertisement.Mileage = Convert.ToInt32(item["rida"]);
                advertisement.Vin = Convert.ToString(item["vin_kodas"]);
                advertisement.EngineCapacity = Convert.ToString(item["darbinis_turis"]);
                advertisement.Model = Convert.ToString(item["modelis"]);
                advertisement.Make = Convert.ToString(item["marke"]);
                advertisement.DoorCount = Convert.ToInt32(item["duru_skaicius"]);
                advertisement.ModelYear = Convert.ToDateTime(item["metai"]);
                advertisement.Price = Convert.ToSingle(item["kaina"]);
                advertisement.Drivetrain = Convert.ToInt32(item["varantieji_ratai"]);
                advertisement.Power = Convert.ToString(item["galia"]);
                advertisement.Damage = Convert.ToString(item["defektai"]);
                advertisement.Color = Convert.ToString(item["spalva"]);
                advertisement.SeatCount = Convert.ToInt32(item["sedimu_vietu_skaicius"]);
                advertisement.WheelPosition = Convert.ToString(item["vairo_padetis"]);
                advertisement.FirstRegistrationCountry = Convert.ToString(item["pirmosios_registracijos_salis"]);
                advertisement.Co2Emissions = Convert.ToString(item["co2_emisija"]);
                advertisement.City = Convert.ToString(item["miestas"]);
                advertisement.Country = Convert.ToString(item["salis"]);
                advertisement.PhoneNumber = Convert.ToString(item["telefono_numeris"]);
                advertisement.Gearbox = Convert.ToString(item["pavaru_deze"]);
                advertisement.BodyType = Convert.ToString(item["kebulo_tipas"]);
                advertisement.FkId = Convert.ToInt32(item["fk_Naudotojasid_Naudotojas"]);
            }
            return advertisement;
        }
    }
}