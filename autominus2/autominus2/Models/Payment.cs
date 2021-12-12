using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autominus2.Models
{
    public class Payment
    {
        public double Sum { get; set; }
        public int id { get; set; }
        public int fk_user { get; set; }

        public Payment(double sum, int fk_user, int id = -1)
        {
            Sum = sum;
            this.id = id;
            this.fk_user = fk_user;
        }
    }
}