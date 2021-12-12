using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autominus2.Models
{
    public class ForumQuestionAnswer
    {
        [DisplayName("Atsakymo id")]
        public int atsakymo_id { get; set; }
        [DisplayName("Atsakymo tekstas")]
        public string atsakymo_tekstas { get; set; }

        [DisplayName("Atsakymo data")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string atsakymo_laikas { get; set; }

        [DisplayName("Klausimo autorius")]
        public int atsakymo_temos_autorius { get; set; }
        [DisplayName("Klausimas")]
        public int atsakymo_klausimas { get; set; }

        public ForumQuestionAnswer()
        {
        }

        public ForumQuestionAnswer(int atsakymo_id, string atsakymo_tekstas, string atsakymo_laikas, int atsakymo_temos_autorius, int atsakymo_klausimas)
        {
            this.atsakymo_id = atsakymo_id;
            this.atsakymo_tekstas = atsakymo_tekstas;
            this.atsakymo_laikas = atsakymo_laikas;
            this.atsakymo_temos_autorius = atsakymo_temos_autorius;
            this.atsakymo_klausimas = atsakymo_klausimas;
        }
    }
}


