using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using autominus2.Utils;

namespace autominus2.Utils
{
    public class UserRepo
    {
        public void InsertUser()
        {
            string sql = "INSERT INTO `Naudotojas`(`vardas`, `pavarde`, `slapyvardis`, `slaptazodis`, `el_pastas`," +
                " `miestas`, `gimimo_metai`, `tipas`, `balansas`, `telefono_numeris`, `galimybes`)" +
                " VALUES ('vardas', 'p', 's', 'slapt', 'e@gmail.com', 'kaunas', NOW(), 0, 100, '+3705', 0)";



        }
    }
}