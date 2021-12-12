using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autominus2.Models
{
    public class ForumQuestionListModel
    {
        [DisplayName("Temos id")]
        public int temos_id { get; set; }
        [DisplayName("Temos Pavadinimas")]
        public string temos_pavadinimas { get; set; }

        [DisplayName("Sukurimo data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime temos_data { get; set; }

        [DisplayName("Temos tekstas")]
        public string temos_tekstas { get; set; }
        [DisplayName("Temos autoriaus id")]
        public int temos_autorius_id { get; set; }

        public ForumQuestionListModel()
        {
        }

        public ForumQuestionListModel(int temos_id, string temos_pavadinimas, DateTime temos_data, string temos_tekstas, int temos_autorius_id)
        {
            this.temos_id = temos_id;
            this.temos_pavadinimas = temos_pavadinimas;
            this.temos_data = temos_data;
            this.temos_tekstas = temos_tekstas;
            this.temos_autorius_id = temos_autorius_id;
        }


        public IList<SelectListItem> questionlist { get; set; }

    }
}
