using autominus2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace autominus2.Utils
{
    public class ForumRepo
    {
        public List<ForumQuestionListModel> GetQuestionsArchives()
        {

            List<ForumQuestionListModel> temos = new List<ForumQuestionListModel>();
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Archyvai` WHERE 1";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                temos.Add(new ForumQuestionListModel
                {
                    temos_id = Convert.ToInt32(item["id"]),
                    temos_pavadinimas = Convert.ToString(item["pavadinimas"]),
                    temos_data = Convert.ToDateTime(item["sukurimo_data"]),
                    temos_tekstas = Convert.ToString(item["tekstas"]),
                    temos_autorius_id = Convert.ToInt32(item["fk_Naudotojasid_Naudotojas"]),
                });
            }
            return temos;
        }
        public List<ForumQuestionListModel> GetQuestions()
        {

            List<ForumQuestionListModel> temos = new List<ForumQuestionListModel>();
            //string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT `id`, `pavadinimas`, `sukurimo_data`, `tekstas`,`fk_Naudotojasid_Naudotojas` FROM `Forumo_tema` WHERE 1";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                temos.Add(new ForumQuestionListModel
                {
                    temos_id = Convert.ToInt32(item["id"]),
                    temos_pavadinimas = Convert.ToString(item["pavadinimas"]),
                    temos_data = Convert.ToDateTime(item["sukurimo_data"]),
                    temos_tekstas = Convert.ToString(item["tekstas"]),
                    temos_autorius_id = Convert.ToInt32(item["fk_Naudotojasid_Naudotojas"]),
                });
            }
            return temos;
        }
        public ForumQuestionListModel GetQuestion(int nr)
        {

            ForumQuestionListModel temos = new ForumQuestionListModel();
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Forumo_tema` WHERE id=" + nr;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                temos.temos_id = Convert.ToInt32(item["id"]);
                temos.temos_pavadinimas = Convert.ToString(item["pavadinimas"]);
                temos.temos_data = Convert.ToDateTime(item["sukurimo_data"]);
                temos.temos_tekstas = Convert.ToString(item["tekstas"]);
                temos.temos_autorius_id = Convert.ToInt32(item["fk_Naudotojasid_Naudotojas"]);
            }
            return temos;
        }
        public List<ForumQuestionListModel> GetQuestionListArchives(int nr)
        {

            List<ForumQuestionListModel> temos = new List<ForumQuestionListModel>();
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Archyvai` WHERE id=" + nr;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                temos.Add(new ForumQuestionListModel
                {
                    temos_id = Convert.ToInt32(item["id"]),
                    temos_pavadinimas = Convert.ToString(item["pavadinimas"]),
                    temos_data = Convert.ToDateTime(item["sukurimo_data"]),
                    temos_tekstas = Convert.ToString(item["tekstas"]),
                    temos_autorius_id = Convert.ToInt32(item["fk_Naudotojasid_Naudotojas"]),
                });
            }
            return temos;
        }
        public List<ForumQuestionListModel> GetQuestionlist(int nr)
        {

            List<ForumQuestionListModel> temos = new List<ForumQuestionListModel>();
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Forumo_tema` WHERE id=" + nr;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                temos.Add(new ForumQuestionListModel
                {
                    temos_id = Convert.ToInt32(item["id"]),
                    temos_pavadinimas = Convert.ToString(item["pavadinimas"]),
                    temos_data = Convert.ToDateTime(item["sukurimo_data"]),
                    temos_tekstas = Convert.ToString(item["tekstas"]),
                    temos_autorius_id = Convert.ToInt32(item["fk_Naudotojasid_Naudotojas"]),
                });
            }
            return temos;
        }
        public List<ForumQuestionAnswer> GetAnswers(int nr)
        {

            List<ForumQuestionAnswer> atsakymai = new List<ForumQuestionAnswer>();
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM `Forumo_atsakymas` WHERE fk_Forumo_temaid_Forumo_tema=" + nr;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                atsakymai.Add(new ForumQuestionAnswer
                {
                    atsakymo_id = Convert.ToInt32(item["id"]),
                    atsakymo_tekstas = Convert.ToString(item["tekstas"]),
                    atsakymo_laikas = Convert.ToString(item["data"]),
                    atsakymo_temos_autorius = Convert.ToInt32(item["fk_Naudotojasid_Naudotojas"]),
                    atsakymo_klausimas = Convert.ToInt32(item["fk_Forumo_temaid_Forumo_tema"]),
                });
            }
            return atsakymai;
        }

        public bool UpdateQuestion(int id, ForumQuestionListModel klausimas)
        {

            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery= @"UPDATE `Forumo_tema` SET `pavadinimas`=?pav,`tekstas`=?tekst WHERE id="+id;
            //string sqlquery = @"UPDATE `forumo_tema` SET `pavadinimas` = ?pav, `tekstas` = ?tekst, WHERE id="+id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);

            mySqlCommand.Parameters.Add("?pav", MySqlDbType.VarChar).Value = klausimas.temos_pavadinimas;
            mySqlCommand.Parameters.Add("?tekst", MySqlDbType.VarChar).Value = klausimas.temos_tekstas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;

        }
        public bool addQuestion(ForumQuestionListModel klausimas)
        {
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `Forumo_tema`(`id`, `pavadinimas`, `sukurimo_data`, `tekstas`, `fk_Naudotojasid_Naudotojas`) VALUES (NULL, ?pav, Now(), ?tekst, 1)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pav", MySqlDbType.VarChar).Value = klausimas.temos_pavadinimas;
            mySqlCommand.Parameters.Add("?tekst", MySqlDbType.VarChar).Value = klausimas.temos_tekstas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }
        public bool addAnswer(int id, int naud, ForumQuestionAnswer atsakymas)
        {
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `Forumo_atsakymas`(`id`, `tekstas`, `data`, `fk_Naudotojasid_Naudotojas`, `fk_Forumo_temaid_Forumo_tema`) VALUES(NULL, ?tekst, Now(),?naudidd, ?idd)";
            //string sqlquery = @"INSERT INTO `Forumo_tema`(`id`, `pavadinimas`, `sukurimo_data`, `tekstas`, `fk_Naudotojasid_Naudotojas`) VALUES (NULL, ?pav, Now(), ?tekst, 1)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);

            mySqlCommand.Parameters.Add("?idd", MySqlDbType.Int32).Value = id;
            mySqlCommand.Parameters.Add("?naudidd", MySqlDbType.Int32).Value = naud;
            mySqlCommand.Parameters.Add("?tekst", MySqlDbType.VarChar).Value = atsakymas.atsakymo_tekstas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;


      
        }
        public bool addToArchives( ForumQuestionListModel klausimas)
        {
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `Archyvai`(`id`, `pavadinimas`, `sukurimo_data`, `tekstas`, `fk_Naudotojasid_Naudotojas`) VALUES (NULL, ?pav, Now(), ?tekst, ?idd)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?idd", MySqlDbType.Int32).Value = klausimas.temos_autorius_id;
            mySqlCommand.Parameters.Add("?pav", MySqlDbType.VarChar).Value = klausimas.temos_pavadinimas;
            mySqlCommand.Parameters.Add("?tekst", MySqlDbType.VarChar).Value = klausimas.temos_tekstas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;  
  
        }

        public bool delete(ForumQuestionListModel klausimas)
        {
            //string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            string conn = "server=sql11.freemysqlhosting.net;port=3306;database=sql11458082;user=sql11458082;password=2dEuRL4y8A";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM `Forumo_tema` WHERE id=?idd";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?idd", MySqlDbType.Int32).Value = klausimas.temos_id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;

        }






    }
}