using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autominus2.Models
{
    public class Strawpoll
    {
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public int count1 { get; set; }
        public int count2 { get; set; }
        public string link { get; set; }

        public Strawpoll()
        {
        }

        public Strawpoll(string question, string answer1, string answer2)
        {
            Question = question;
            Answer1 = answer1;
            Answer2 = answer2;
        }

    }
}