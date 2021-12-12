﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using autominus2.Utils;
using autominus2.Models;
using MySql.Data.MySqlClient;
using PayPal.Api;

namespace autominus.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult ProcCloseQuestion()
        {
            return View();
        }

        public ActionResult ProcPaymentt()
        {
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            double sum = double.Parse(String.Format("{0}", Request.Form["balanceInput"]));
            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseUrI = Request.Url.Scheme + "://" + Request.Url.Authority + "Home/ProcPayment?";
                    var guid = Convert.ToString((new Random()).Next(10000));
                    //double sum = double.Parse(String.Format("{0}", Request.Form["balanceInput"]));
                    var createdPayment = PaypalHandler.CreatePayment(apiContext, baseUrI + "guid=" + guid, sum);

                    //get links returned from paypal response
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;

                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    //
                    var guid = Request.Params["guid"];
                    var executedPayment = PaypalHandler.ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if(executedPayment.state.ToLower() != "approved")
                    {
                        return View("paymentFailure");
                    }
                }
            }
            catch (Exception ex)
            {
                PaypalLogger.Log("Error: " + ex.Message);
                return View("paymentFailure");
            }
            autominus2.Models.Payment ourPayment = new autominus2.Models.Payment(sum, OurSession.LoggedInUser.Id);
            return View("BalanceReport");
        }

        public ActionResult ProcPayment()
        {
            return View();
        }

        public ActionResult ProcProfileEdit()
        {
            return View();
        }

        public ActionResult ProcHelpRequest()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public ActionResult ProcLogin()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (OurSession.InRegistration)
            {
                string passw = String.Format("{0}", Request.Form["registerPasswordInput"]);
                string passwConfirm = String.Format("{0}", Request.Form["registerPasswordConfirmInput"]);
                string name = String.Format("{0}", Request.Form["registerNameInput"]);
                string lastName = String.Format("{0}", Request.Form["registerLastNameInput"]);
                string userName = String.Format("{0}", Request.Form["registerUserNameInput"]);
                string city = String.Format("{0}", Request.Form["registerCityInput"]);
                DateTime date = DateTime.Now;
                bool falseDate = false;
                try
                {
                    date = DateTime.Parse(Request.Form["registerBirthDateInput"]);
                }
                catch { falseDate = true; }
                
                string phone = String.Format("{0}", Request.Form["registerPhoneNumberInput"]);
                string email = String.Format("{0}", Request.Form["registerEmailInput"]);

                if(passw.Length != 0 && passwConfirm.Length != 0 && name.Length != 0 &&
                    lastName.Length != 0 && userName.Length != 0 && city.Length != 0 && !falseDate)
                {
                    User usr = new User(name, lastName, userName, passw, email, city, date, 0, 0, phone, 0);
                    UserRepo.InsertUser(usr);
                }
                OurSession.InRegistration = false;


            }
            return View();
        }
        public ActionResult HelpEmail()
        {

            return View();
        }
        public ActionResult HelpLive()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Profile()
        {
            
            return View();
        }
        //-------------------------------------------------------------------------------------------------------
        public ActionResult Forum()
        {
            return View();
        }
        public ActionResult NewForumQuestion()
        {
            return View();
        }
        public ActionResult ForumQuestion()
        {
            return View();
        }
        public ActionResult EditQuestion()
        {
            return View();
        }
        public ActionResult ForumQuestionArchive()
        {
            return View();
        }
        public ActionResult ForumQuestionAnswer()
        {
            return View();
        }

        public ActionResult ProfileEdit()
        {
            
            return View();
        }

        public ActionResult AddBalance()
        {
            
            return View();
        }
        public ActionResult AdListView()
        {
            return View();
        }

        public ActionResult AdView()
        {
            return View();
        }

        public ActionResult AdEditView()
        {
            return View();
        }

        public ActionResult AdCreateView()
        {
            return View();
        }

        public ActionResult BalanceReport()
        {
            
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult HelpReview()
        {
            
            return View();
        }



        public ActionResult VartotojuSarasoLangas()
        {
            return View();
        }

        public ActionResult PasirinktoVartotojoLangas()
        {
            return View();
        }
        public ActionResult Salinti()
        {
            ViewData["Message"] = "Šalinimas";
            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Strawpoll()
        {
            return View();
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
