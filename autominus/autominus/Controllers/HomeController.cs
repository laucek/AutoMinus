using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using autominus.Models;
using Microsoft.AspNetCore.Authorization;


namespace autominus.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Login()
        {

            return View();
        }
        public IActionResult HelpEmail()
        {

            return View();
        }
        public IActionResult HelpLive()
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Profile()
        {
            
            return View();
        }
        //-------------------------------------------------------------------------------------------------------
        public IActionResult Forum()
        {
            return View();
        }
        public IActionResult NewForumQuestion()
        {
            return View();
        }
        public IActionResult ForumQuestion()
        {
            return View();
        }
        public IActionResult EditQuestion()
        {
            return View();
        }
        public IActionResult ForumQuestionArchive()
        {
            return View();
        }
        public IActionResult ForumQuestionAnswer()
        {
            return View();
        }

        public IActionResult ProfileEdit()
        {
            
            return View();
        }

        public IActionResult AddBalance()
        {
            
            return View();
        }
        public IActionResult AdListView()
        {
            return View();
        }

        public IActionResult AdView()
        {
            return View();
        }

        public IActionResult AdEditView()
        {
            return View();
        }

        public IActionResult BalanceReport()
        {
            
            return View();
        }

        public IActionResult Help()
        {
            
            return View();
        }

        public IActionResult HelpReview()
        {
            
            return View();
        }



        public IActionResult VartotojuSarasoLangas()
        {
            return View();
        }

        public IActionResult PasirinktoVartotojoLangas()
        {
            return View();
        }
        public IActionResult Salinti()
        {
            ViewData["Message"] = "Šalinimas";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Strawpoll()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
