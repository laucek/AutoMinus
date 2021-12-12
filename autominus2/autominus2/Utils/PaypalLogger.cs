using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace autominus2.Utils
{
    public class PaypalLogger
    {
        public static string LogDirectoryPath = Environment.CurrentDirectory;

        public static void Log(String message)
        {
            try
            {
                StreamWriter writer = new StreamWriter("D:\\Univeras\\ISPRepo\\AutoMinus\\autominus2\\autominus2\\PaypalError.txt", true);
                writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "--->" + message);
                writer.Close();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}