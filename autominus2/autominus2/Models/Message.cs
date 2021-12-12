using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autominus2.Models
{
    public class Message
    {
        public int fk_user { get; set; }
        public string message { get; set; }

        public Message(int fk_user, string message)
        {
            this.fk_user = fk_user;
            this.message = message;
        }
    }
}