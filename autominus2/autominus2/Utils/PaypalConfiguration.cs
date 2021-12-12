using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace autominus2.Utils
{
    public class PaypalConfiguration
    {
        public static string ClientId;
        public static string ClientSecret;
        
        static PaypalConfiguration()
        {
            var config = GetConfig();
            //ClientId = config["clientId"];
            ClientId = "AZkFfuMTlrUutw71H6q9RaucfWtw7ip1pwa_U-PziE1tqXbMRtBUiBTxFrHmmvehlmL3ESrxBwRRp5Vb";
            //ClientSecret = config["clientSecret"];
            ClientSecret = "EM2REGTy2rbGqzm8CCv0iE7zNbMNe_sllcbrrZmRCcPFEvHrAsstOYGP4zm-SclKuEB_8ugmd87BCdKo";
        }

        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        //Create access token
        private static string GetAccessToken()
        {
            string acessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return acessToken;
        }

        //Apicontext obj
        public static APIContext GetAPIContext()
        {
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }

    }
}