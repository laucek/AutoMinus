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
                string sql = "INSERT INTO `skelbimas`(`skelbimo_sukurimo_data`, `kuro_tipas`, `rida`, `vin_kodas`, `darbinis_turis`," +
                " `modelis`, `marke`, `duru_skaicius`, `metai`, `kaina`, `varantieji_ratai`, `galia`, `defektai`, `spalva`," +
                " `sedimu_vietu_skaicius`, `vairo_padetis`, `pirmosios_registracijos_salis`, `co2_emisija`, `miestas`, `salis`, " +
                " `telefono_numeris`, `pavaru_deze`, `kebulo_tipas`, `fk_Naudotojasid_Naudotojas`)" +
                $" VALUES (NOW(), '{ad.FuelType}', '{ad.Mileage}', '{ad.Vin}', '{ad.EngineCapacity}', '{ad.Model}', '{ad.Make}', '{ad.DoorCount}'," +
                $" '{ad.ModelYear}', '{ad.Price}', '{ad.Drivetrain}', '{ad.Power}', '{ad.Damage}', '{ad.Color}'," +
                $" '{ad.SeatCount}', '{ad.WheelPosition}', '{ad.FirstRegistrationCountry}', '{ad.Co2Emissions}', '{ad.City}', '{ad.Country}'," +
                $" '{ad.PhoneNumber}', '{ad.Gearbox}', '{ad.BodyType}', {OurSession.LoggedInUser.Id})";

                //string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
                string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
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
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=;convert zero datetime = True";
            // string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A; convert zero datetime=True";
            //string conn = "server=localhost;port=3306;database=dbname;user=root;password=; convert zero datetime=True";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from skelbimas";
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
                    AdCreationDate = Convert.ToDateTime(item["skelbimo_sukurimo_data"]),
                    FuelType = Convert.ToString(item["kuro_tipas"]),
                    Mileage = Convert.ToInt32(item["rida"]),
                    Vin = Convert.ToString(item["vin_kodas"]),
                    EngineCapacity = Convert.ToString(item["darbinis_turis"]),
                    Model = Convert.ToString(item["modelis"]),
                    Make = Convert.ToString(item["marke"]),
                    DoorCount = Convert.ToInt32(item["duru_skaicius"]),
                    ModelYear = Convert.ToDateTime(item["metai"]),
                    Price = Convert.ToSingle(item["kaina"]),
                    Drivetrain = Convert.ToInt32(item["varantieji_ratai"]),
                    Power = Convert.ToString(item["galia"]),
                    Damage = Convert.ToString(item["defektai"]),
                    Color = Convert.ToString(item["spalva"]),
                    SeatCount = Convert.ToInt32(item["sedimu_vietu_skaicius"]),
                    WheelPosition = Convert.ToString(item["vairo_padetis"]),
                    FirstRegistrationCountry = Convert.ToString(item["pirmosios_registracijos_salis"]),
                    Co2Emissions = Convert.ToString(item["co2_emisija"]),
                    City = Convert.ToString(item["miestas"]),
                    Country = Convert.ToString(item["salis"]),
                    PhoneNumber = Convert.ToString(item["telefono_numeris"]),
                    Gearbox = Convert.ToString(item["pavaru_deze"]),
                    BodyType = Convert.ToString(item["kebulo_tipas"]),
                    FkId = Convert.ToInt32(item["fk_Naudotojasid_Naudotojas"]),
                    Id = Convert.ToInt32(item["id"])
                });
            }
            return advertisements;
        }

        public Advertisement getAdvertisement(int id)
        {
            Advertisement advertisement = new Advertisement();
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=;convert zero datetime = True";
            // string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A; convert zero datetime=True";
            //string conn = "server=localhost;port=3306;database=dbname;user=root;password=; convert zero datetime=True";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from skelbimas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
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
                advertisement.Id = Convert.ToInt32(item["id"]);
            }
            return advertisement;
        }

        public bool updateAdvertisement(Advertisement advertisement)
        {
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
           // string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=dbname;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            //string sqlquery = @"UPDATE Skelbimas a SET a.vin_kodas=?vin, a.modelis=?mod WHERE a.id=?idas";
            string sqlquery = @"UPDATE skelbimas a SET a.kuro_tipas=?kuras, a.rida=?rida, a.vin_kodas=?vin, a.darbinis_turis=?turis, a.modelis=?model, a.marke=?marke, 
            a.duru_skaicius=?durys, a.metai=?metai, a.kaina=?kaina, a.varantieji_ratai=?ratai, a.galia=?galia, a.defektai=?defektai, a.spalva=?spalva, 
            a.sedimu_vietu_skaicius=?vietos, a.vairo_padetis=?vairas, a.pirmosios_registracijos_salis=?regsalis, a.co2_emisija=?co2, a.miestas=?miestas,
            a.salis=?salis, a.telefono_numeris=?tel, a.pavaru_deze=?deze, a.kebulo_tipas=?kebulas WHERE a.id=?idas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kuras", MySqlDbType.VarChar).Value = advertisement.FuelType;
            mySqlCommand.Parameters.Add("?rida", MySqlDbType.Int32).Value = advertisement.Mileage;
            mySqlCommand.Parameters.Add("?vin", MySqlDbType.VarChar).Value = advertisement.Vin;
            mySqlCommand.Parameters.Add("?turis", MySqlDbType.VarChar).Value = advertisement.EngineCapacity;
            mySqlCommand.Parameters.Add("?model", MySqlDbType.VarChar).Value = advertisement.Model;
            mySqlCommand.Parameters.Add("?marke", MySqlDbType.VarChar).Value = advertisement.Make;
            mySqlCommand.Parameters.Add("?durys", MySqlDbType.Int32).Value = advertisement.DoorCount;
            mySqlCommand.Parameters.Add("?metai", MySqlDbType.DateTime).Value = advertisement.ModelYear;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Float).Value = advertisement.Price;
            mySqlCommand.Parameters.Add("?ratai", MySqlDbType.Int32).Value = advertisement.Drivetrain;
            mySqlCommand.Parameters.Add("?galia", MySqlDbType.VarChar).Value = advertisement.Power;
            mySqlCommand.Parameters.Add("?defektai", MySqlDbType.VarChar).Value = advertisement.Damage;
            mySqlCommand.Parameters.Add("?spalva", MySqlDbType.VarChar).Value = advertisement.Color;
            mySqlCommand.Parameters.Add("?vietos", MySqlDbType.Int32).Value = advertisement.SeatCount;
            mySqlCommand.Parameters.Add("?vairas", MySqlDbType.VarChar).Value = advertisement.WheelPosition;
            mySqlCommand.Parameters.Add("?regsalis", MySqlDbType.VarChar).Value = advertisement.FirstRegistrationCountry;
            mySqlCommand.Parameters.Add("?co2", MySqlDbType.VarChar).Value = advertisement.Co2Emissions;
            mySqlCommand.Parameters.Add("?miestas", MySqlDbType.VarChar).Value = advertisement.City;
            mySqlCommand.Parameters.Add("?salis", MySqlDbType.VarChar).Value = advertisement.Country;
            mySqlCommand.Parameters.Add("?tel", MySqlDbType.VarChar).Value = advertisement.PhoneNumber;
            mySqlCommand.Parameters.Add("?deze", MySqlDbType.VarChar).Value = advertisement.Gearbox;
            mySqlCommand.Parameters.Add("?kebulas", MySqlDbType.VarChar).Value = advertisement.BodyType;
            mySqlCommand.Parameters.Add("?idas", MySqlDbType.Int32).Value = advertisement.Id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool deleteAdvertisement(int id)
        {
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            //string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=dbname;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM skelbimas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
    }
}