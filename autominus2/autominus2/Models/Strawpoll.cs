using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autominus2.Models
{
    public class Strawpoll
    {
        public string Question;
        public string Answer1;
        public string Answer2;
        public int count1;
        public int count2;
        public string link;

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