using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace autominus2.Models
{
    public class Question
    {

        [DisplayName("Klausimas")]
        public string QuestionInDB { get; set; }
        [DisplayName("id")]
        public int? id { get; set; }
        public int atsakyta { get; set; }
        [DisplayName("vartotojas")]
        public int fk_user_id { get; set; }
        public List<Message> messages { get; set; }

        public Question()
        {
            messages = new List<Message>();
        }

        public Question(string questionInDB, int? id, int atsakyta, int fk_user_id, List<Message> messages) : this(questionInDB, id, atsakyta, fk_user_id)
        {
            messages = new List<Message>();
        }

        public Question(string questionInDB, int? id, int fk_user_id, int atsakyta)
        {
            messages = new List<Message>();
            QuestionInDB = questionInDB;
            this.id = id;
            this.atsakyta = atsakyta;
            this.fk_user_id = fk_user_id;
        }
    }
}