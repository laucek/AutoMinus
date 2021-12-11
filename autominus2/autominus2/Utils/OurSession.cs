using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using autominus2.Models;

namespace autominus2.Utils
{
    public static class OurSession
    {
        public static bool InRegistration = false;
        public static User LoggedInUser = null;
        public static User EditObject = null;
        public static string helpRequestString = null;
        public static long? helpIndex = null;
        public static Payment RecentPayment = null;
        public static Languages.Language Language = new Languages.English(); 
    
    }
}