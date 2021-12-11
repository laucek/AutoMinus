using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using autominus2.Models;
using MySql.Data.MySqlClient;

namespace autominus2.Utils
{
    public class CarsRepo
    {
        //public void InsertAdvertisement()
        //{
        //    string sql = "INSERT INTO `Skelbimas`(`skelbimo_sukurimo_data`, `kuro_tipas`, `rida`, `	vin_kodas`, `darbinis_turis`," +
        //        " `modelis`, `marke`, `duru_skaicius`, `metai`, `kaina`, `varantieji_ratai`, `galia`, `defektai`, `spalva`," +
        //        " `sedimu_vietu_skaicius`, `vairo_padetis`, `pirmosios_registracijos_salis`, `co2_emisija`, `miestas`, `salis`, " +
        //        " `telefono_numeris`, `pavaru_deze`, `kebulo_tipas`)" +
        //        " VALUES (NOW(), 'kuras', 10000, 'WBA48941321', '2999', 'modelis', 'marke', 4, NOW(), 2599, 2, '180', 'defektai', 'spalva'" +
        //        " 5, 'vairas', 'psalis', '190', 'miestas', 'salis', '+370804', 'pavarudeze', 'kebulas')";
        //}
        public static bool InsertAdvertisement(Advertisement ad)
        {
            try
            {
                string sql = "INSERT INTO `Skelbimas`(`skelbimo_sukurimo_data`, `kuro_tipas`, `rida`, `	vin_kodas`, `darbinis_turis`," +
                " `modelis`, `marke`, `duru_skaicius`, `metai`, `kaina`, `varantieji_ratai`, `galia`, `defektai`, `spalva`," +
                " `sedimu_vietu_skaicius`, `vairo_padetis`, `pirmosios_registracijos_salis`, `co2_emisija`, `miestas`, `salis`, " +
                " `telefono_numeris`, `pavaru_deze`, `kebulo_tipas`)" +
                $" VALUES (NOW(), 'kuras', 10000, 'WBA48941321', '2999', 'modelis', 'marke', 4, NOW(), 2599, 2, '180', 'defektai', 'spalva'" +
                $" 5, 'vairas', 'psalis', '190', 'miestas', 'salis', '+370804', 'pavarudeze', 'kebulas')";

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
    }
}