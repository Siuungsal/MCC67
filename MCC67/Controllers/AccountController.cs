using MCC67.Context;
using MCC67.Models;
using MCC67.Repositories.Data;
using MCC67.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;

namespace MCC67.Controllers
{
    public class AccountController : Controller
    {
        //MyContext myContext;
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        #region Get
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #endregion Get

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Logon logon)
        {
            if (!ModelState.IsValid)
            {
                return Login();
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44303/api/");
                var postTask = client.PostAsJsonAsync<Logon>("Account", logon);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var parsedObject = JObject.Parse(readTask);
                    var dataOnly = parsedObject["token"].ToString();

                    HttpContext.Session.SetString("Token", dataOnly);
                    var token = HttpContext.Session.GetString("Token");
                    //login = JsonConvert.DeserializeObject<Login>(dataOnly);
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", $"{HttpContext.Session.GetString("Token")}");
                }
                return RedirectToAction("Index", "Supplier");
            }

            return View();

            //=>var result = accountRepository.Post(email, password);

            //=>HttpContext.Session.SetString("Id", result.Id.ToString());
            //=>HttpContext.Session.SetString("Name", result.Name);
            //=>HttpContext.Session.SetString("Email", result.Email);
            //HttpContext.Session.SetString("Role", result.Role);
            //=>HttpContext.Session.SetInt32("TotalRole", result.Role.Count);

            /*for(int i = 0 ; i < result.Role.Count; i++)
            {
                HttpContext.Session.SetString("Roles " +i, result.Role.);
            }*/

            //=>int counter = 1;

            /*=>foreach (var item in result.Role)
            {
                HttpContext.Session.SetString("Roles " + counter, item.Name);
                counter++;
            }<=*/

            //>if (result != null)
            //>{
            //return Json(result);
            //>return RedirectToAction("Index", "Supplier");
            /*Login login = new Login();

            foreach (object[] item in result)
            {
                login.Id = (int)item[0];
                login.Name = (string)item[1];
                login.Role = (string)item[2];
            }

            return View(login);*/
            //>}
            /*=>else
            {
                TempData["Error"] = "Login Failed";

                return RedirectToAction("Login", "Account");
            }<=*/

            return View("Success");
            
        }
        #endregion Login

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return Register();
            }

            int result = accountRepository.Register(user);
            if (result > 0)
                return RedirectToAction("Index", "Account");
            return View();
        }
        #endregion Register

        #region ChangePassword

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(User user)
        {
            if (!ModelState.IsValid)
            {
                return ChangePassword();
            }

            int result = accountRepository.ChangePassword(user);
            if (result > 0)
                return RedirectToAction("Index", "Account");
            return View();
        }

        #endregion ChangePassword

        #region Logout
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout(User user)
        {
            if (!ModelState.IsValid)
            {
                return Logout();
            }

            int result = accountRepository.Logout(user);
            if (result > 0)
            {
                return View("Success");
            }
            return View("Index");
        }
        #endregion Logout

    }
}
