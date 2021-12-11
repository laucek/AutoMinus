using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using autominus2.Models;
using autominus2.Utils;

namespace autominus.Controllers
{
    public class HomeController : Controller
    {

        ModeratorRepo moderatorRepo = new ModeratorRepo();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Login()
        {
            if (OurSession.InRegistration)
            {

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
            return View(moderatorRepo.getUsers());
        }
        // GET: Klientas/Edit/5
        [HttpGet]
        public ActionResult PasirinktoVartotojoLangas(int id)
        {
            return View(moderatorRepo.getUser(id));
        }

        // POST: Klientas/Edit/5
        [HttpPost]
        public ActionResult PasirinktoVartotojoLangas(int id, User collection)
            {
            try
            {
                // Atnaujina kliento informacija
                if (ModelState.IsValid)
                {
                    moderatorRepo.updateUser(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
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
