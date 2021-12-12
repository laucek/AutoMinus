using autominus2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace autominus2.Utils
{
    public class ModeratorRepo
    {
        StrawPollNET.Models.CreatedPoll newPoll;
        public List<User> getUsers()
        {
            List<User> users = new List<User>();
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from naudotojas";
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
        public static User getUser(int id)
        {
            User user = new User();
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from naudotojas where id=?id";
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
                string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE naudotojas a SET a.vardas=?var, a.el_pastas=?el, a.tipas=?tip, a.galimybes=?gal WHERE a.id=?idas";
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
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM naudotojas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }


        public bool StrawPoll(Strawpoll strawpoll)
        {
            try
            {
                List<string> allOptions = new List<string>();
                bool multipleChoice = false;
                StrawPollNET.Enums.DupCheck dupCheck = StrawPollNET.Enums.DupCheck.Normal;
                bool requireCaptcha = true;
                allOptions.Add(strawpoll.Answer1);
                allOptions.Add(strawpoll.Answer2);
                // Create the poll
                newPoll = createPoll(strawpoll.Question, allOptions, multipleChoice, dupCheck, requireCaptcha).Result;
                
                // Show poll link
                string sql = "INSERT INTO `apklausa`(`Antraste`, `atsakymas1`, `atsakymas2`, `linkas`,`pollId`, `fk_Naudotojasid_Naudotojas`)" +
                $" VALUES ('{strawpoll.Question}', '{strawpoll.Answer1}', '{strawpoll.Answer2}', '{newPoll.PollUrl}','{newPoll.Id}',  1)";
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
           /* string pollTitle = "Hello, this is my first poll";
            List<string> allOptions = new List<string>() { "Yes", "No", "Idk", "Laba diena" };
            bool multipleChoice = true;
            StrawPollNET.Enums.DupCheck dupCheck = StrawPollNET.Enums.DupCheck.Normal;
            bool requireCaptcha = true;

            // Create the poll
            StrawPollNET.Models.CreatedPoll newPoll = StrawPollNET.API.Create.CreatePoll(pollTitle, allOptions, multipleChoice, dupCheck, requireCaptcha);

            // Show poll link
            Console.WriteLine($"Go vote at my new poll, available here: {newPoll.PollUrl}");*/
            

        }


        public static Strawpoll getPoll()
        {
            Strawpoll strawpoll = new Strawpoll();

            string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "SELECT * FROM `Apklausa` ORDER BY id DESC LIMIT 1";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                strawpoll.Question = Convert.ToString(item["Antraste"]);
                strawpoll.Answer1 = Convert.ToString(item["atsakymas1"]);
                strawpoll.Answer2 = Convert.ToString(item["atsakymas2"]);
                strawpoll.link = Convert.ToString(item["linkas"]);
            }
          /*  var getResp = getPoll(strawpoll.count1).Result;
            List<string> asd = new List<string>();
            List<int> dsa = new List<int>();
            foreach (KeyValuePair<string, int> result in getResp.Results)
            {
                asd.Add(result.Key);
                dsa.Add(result.Value);
            }

            strawpoll.Answer1 = asd[0];
            strawpoll.count1 = dsa[0];
            strawpoll.Answer2 = asd[1];
            strawpoll.count2 = dsa[1];*/
            return strawpoll;
        }

        private async static Task<StrawPollNET.Models.CreatedPoll> createPoll(string title, List<string> options, bool multi, StrawPollNET.Enums.DupCheck dupCheck, bool captcha)
        {
            return await StrawPollNET.API.Create.CreatePollAsync(title, options, multi, dupCheck, captcha);
        }

        private async static Task<StrawPollNET.Models.FetchedPoll> getPoll(int pollId)
        {
            return await StrawPollNET.API.Get.GetPollAsync(pollId);
        }


        public List<Question> getQuestions()
        {
            List<Question> questions = new List<Question>();
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from Pagalbos_prasymas where atsakyta = 0";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                questions.Add(new Question
                {
                    id = Convert.ToInt32(item["id"]),
                    QuestionInDB = Convert.ToString(item["Klausimas"]),
                    fk_user_id = Convert.ToInt32(item["fk_naudotojas"]),
                    atsakyta = Convert.ToInt32(item["atsakyta"])
                });
            }
            return questions;
        }
        public static Question getQuestion(int? id)
        {
            Question q = new Question();
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from Pagalbos_prasymas where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                q.id = Convert.ToInt32(item["id"]);
                q.QuestionInDB = Convert.ToString(item["Klausimas"]);
                q.fk_user_id = Convert.ToInt32(item["fk_Naudotojas"]);
                q.atsakyta = Convert.ToInt32(item["atsakyta"]);
            }
            return q;
        }

        public bool updateQuestion(int? id, Question question)
        {
            try { 
            string conn = "server=localhost;port=3306;database=nauja;user=root;password=";
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            //string sqlquery = @"UPDATE pagalbos_prasymas a SET a.atsakyta=?at WHERE a.id=?idas";
            string sqlquery = @"UPDATE Pagalbos_prasymas a SET a.atsakyta=?at WHERE a.id=?idas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?idas", MySqlDbType.Int32).Value = question.id;
            mySqlCommand.Parameters.Add("?at", MySqlDbType.Int32).Value = 1;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
            }
            catch (Exception exc)
            {
                exc.GetType().ToString();
                return false;
            }
}
    }
}