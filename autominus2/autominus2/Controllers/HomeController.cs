using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using autominus2.Models;
using autominus2.Utils;
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
            float sum = Single.Parse(String.Format("{0}", Request.Form["balanceInput"]));
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

        CarsRepo carsRepo = new CarsRepo();
        public ActionResult ProcHelpRequest()
        {
            return View();
        }

        ModeratorRepo moderatorRepo = new ModeratorRepo();

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

            return View(moderatorRepo.getQuestions());
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
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        ForumRepo questionrep = new ForumRepo();
        public ActionResult Forum()
        {

            return View(questionrep.GetQuestions());
        }


        public ActionResult NewForumQuestion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewForumQuestion(ForumQuestionListModel collect)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    questionrep.addQuestion(collect);
                }
                return RedirectToAction("Forum");
            }
            catch
            {
                return View(collect);

            }
        }
        [HttpGet]
        public ActionResult ForumQuestion(int id)
        {
            return View(questionrep.GetQuestionlist(id));
        }
        [HttpGet]
        public ActionResult EditQuestion(int id)
        {
            return View(questionrep.GetQuestion(id));
        }
        [HttpPost]
        public ActionResult EditQuestion(int id, ForumQuestionListModel collect)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    questionrep.UpdateQuestion(id, collect);
                }
                return RedirectToAction("Forum");
            }
            catch
            {
                return View(collect);
            }
        }
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------

        //public ActionResult ForumQuestion(int id)
        //{
        //    return View(questionrep.GetQuestionsArchives(id));
        //}

        
        [HttpGet]
        public ActionResult ForumQuestionArchives(int id)
        {
            return View(questionrep.GetQuestionListArchives(id));
        }

        [HttpGet]
        public ActionResult ForumQuestionArchive(int naud)
        {
            return View(questionrep.GetQuestion(naud));
        }
        [HttpGet]
        public ActionResult ForumArchives()
        {
            return View(questionrep.GetQuestionsArchives());
        }
        [HttpPost]
        public ActionResult ForumQuestionArchive(ForumQuestionListModel collect)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    questionrep.addToArchives(collect);
                    questionrep.delete(collect);
                }
                return RedirectToAction("ForumArchives");
            }
            catch
            {
                return View(collect);

            }
        }

        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        public ActionResult ForumQuestionAnswer(int id)
        {
            return View(questionrep.GetAnswers(id));
        }

        public ActionResult NewForumAnswer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewForumAnswer(int id, int naud, ForumQuestionAnswer collect)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    questionrep.addAnswer(id, naud,collect);
                }
                return RedirectToAction("Forum");
            }
            catch
            {
                return View(collect);

            }
        }
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------

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
            return View(carsRepo.getAdvertisements());
        }

        [HttpGet]
        public ActionResult AdView(int id)
        {
            return View(carsRepo.getAdvertisement(id));
        }

        public ActionResult AdEditView(int id)
        {
            return View(carsRepo.getAdvertisement(id));
        }

        [HttpPost]
        public ActionResult AdEditView(int id, Advertisement collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carsRepo.updateAdvertisement(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        public ActionResult AdCreateView()
        {
            return View();
        }

        public ActionResult AdCreate()
        {
            DateTime adCreationDate = DateTime.Now;
            string make = String.Format("{0}", Request.Form["AdCreateMarkeInput"]);
            string model = String.Format("{0}", Request.Form["AdCreateModelisInput"]);
            DateTime modelYear = DateTime.Now;//String.Format("{0}", Request.Form["AdCreateDataInput"]);
            bool falseDate = false;
            try
            {
                modelYear = DateTime.Parse(Request.Form["AdCreateDataInput"]);
            }
            catch { falseDate = true; }
            string bodyType = String.Format("{0}", Request.Form["AdCreateKebulasInput"]);
            string fuelType = String.Format("{0}", Request.Form["AdCreateKurasInput"]);
            string gearbox = String.Format("{0}", Request.Form["AdCreateDezeInput"]);
            int doorCount = Int32.Parse(Request.Form["AdCreateDurysInput"]);
            string damage = String.Format("{0}", Request.Form["AdCreateDefektaiInput"]);
            string wheelPosition = String.Format("{0}", Request.Form["AdCreateVairasInput"]);
            string color = String.Format("{0}", Request.Form["AdCreateSpalvaInput"]);
            int mileage = Int32.Parse(Request.Form["AdCreateRidaInput"]);
            string engineCapacity = String.Format("{0}", Request.Form["AdCreateTurisInput"]);
            string power = String.Format("{0}", Request.Form["AdCreateGaliaInput"]);
            string vin = String.Format("{0}", Request.Form["AdCreateVinInput"]);
            float price = Single.Parse(Request.Form["AdCreateKainaInput"]);
            int drivetrain = Int32.Parse(Request.Form["AdCreateRataiInput"]);
            int seatCount = Int32.Parse(Request.Form["AdCreateVietosInput"]);
            string firstRegistrationCountry = String.Format("{0}", Request.Form["AdCreateRegistracijaInput"]);
            string co2Emissions = String.Format("{0}", Request.Form["AdCreateCo2Input"]);
            string city = String.Format("{0}", Request.Form["AdCreateMiestasInput"]);
            string country = String.Format("{0}", Request.Form["AdCreateSalisInput"]);
            string phoneNumber = String.Format("{0}", Request.Form["AdCreateTelefonasInput"]);

            if (make.Length != 0 && model.Length != 0 && bodyType.Length != 0 &&
                fuelType.Length != 0 && gearbox.Length != 0 && damage.Length != 0 &&
                wheelPosition.Length != 0 && color.Length != 0 && engineCapacity.Length != 0 &&
                power.Length != 0 && vin.Length != 0 && firstRegistrationCountry.Length != 0 &&
                co2Emissions.Length != 0 && city.Length != 0 && country.Length != 0 && phoneNumber.Length != 0 && !falseDate)
            {
                Advertisement ad = new Advertisement(adCreationDate, fuelType, mileage, vin, engineCapacity, model, make,
                    doorCount, modelYear, price, drivetrain, power, damage, color, seatCount, wheelPosition,
                    firstRegistrationCountry, co2Emissions, city, country, phoneNumber, gearbox, bodyType);
                CarsRepo.InsertAdvertisement(ad);
            }
            return Index();
        }

        public ActionResult AdDelete(int id, FormCollection collection)
        {
            try
            {
                carsRepo.deleteAdvertisement(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
            return View(ModeratorRepo.getUser(id));
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

                return RedirectToAction("VartotojuSarasoLangas");
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
        // GET: Klientas/Delete/5
        [HttpGet]
        public ActionResult Salinti(int id)
        {
            return View(ModeratorRepo.getUser(id));
        }

        // POST: Klientas/Delete/5
        [HttpPost]
        public ActionResult Salinti(int id, FormCollection collection)
        {
            try
            {
                moderatorRepo.deleteUser(id);

                return RedirectToAction("VartotojuSarasoLangas");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult HelpClose(int id)
        {
            return View(ModeratorRepo.getQuestion(id));
        }
        [HttpPost]
        public ActionResult HelpClose(int id, Question collection)
        {
            try
            {
                moderatorRepo.updateQuestion(id, collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult HelpAnswer(int? id)
        {
            return View(ModeratorRepo.getQuestion(id));
        }
        [HttpPost]
        public ActionResult HelpAnswer(string helpReviewTalkMsgMod)
        {
            try
            {
                UserRepo.InsertHelpMsg(helpReviewTalkMsgMod);

                return RedirectToAction("HelpAnswer");
            }
            catch
            {
                return View();
            }
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
        public ActionResult StrawpollAnsw()
        {
            return View();
        }
        public ActionResult Strawpoll1()
        {
            string ques = String.Format("{0}", Request.Form["StrawPollQuestion"]);
            string ans1 = String.Format("{0}", Request.Form["StrawPollAnswer1"]);
            string ans2 = String.Format("{0}", Request.Form["StrawPollAnswer2"]);
            Strawpoll strawpoll = new Strawpoll(ques, ans1, ans2);

            moderatorRepo.StrawPoll(strawpoll);
            return Index();
        }
        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
