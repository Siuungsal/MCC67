using MCC67.Context;
using MCC67.Models;
using MCC67.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace MCC67.Controllers
{
    public class SupplierController : Controller
    {
        MyContext myContext;
        SupplierRepository supplierRepository;
        HttpClient client;

        public SupplierController(SupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
            client = new HttpClient();
        }

        #region Get
        [HttpGet]
        public IActionResult Index()
        {
            //List<Supplier> produk = myContext.Supplier.ToList();

            var f = client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", HttpContext.Session.GetString("Token"));

            //HttpContext.Session.GetInt32("TotalRole");

            //int counter = 0;

            //for(int i = 1; i <= HttpContext.Session.GetInt32("TotalRole"); i++)
            //{
            //    /*if (HttpContext.Session.GetString("Roles " + 1) == "Member"){
            //        return Json("403");
            //    }*/
            //    if (HttpContext.Session.GetString("Roles " + i) == "Member")
            //    {
            //        counter++;
            //    }
            //    /*else {
            //        return View();
            //    }*/
            //}

            /*=>if(counter == 0)
            {
                return Json("403");
            }<=*/

            //=>var supplier = supplierRepository.Get();
            //var supplier = myContext.Supplier.Where(x => x.Name == "Indofood").ToList();
            /*=>if (supplier.Count() != 0)
            {
                return View(supplier);
            }<=*/

            IEnumerable<Supplier> supplier = null;

            //using (var client = new HttpClient())
            //{
                client.BaseAddress = new Uri("https://localhost:44303/api/");
                var responseTask = client.GetAsync("Supplier");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var parsedObject = JObject.Parse(readTask);
                    var dataOnly = parsedObject["data"].ToString();

                    supplier = JsonConvert.DeserializeObject<List<Supplier>>(dataOnly);
                }
                else
                {
                    supplier = Enumerable.Empty<Supplier>();

                    ModelState.AddModelError(string.Empty, "Server error. please contact administrator yg.");
                }
            //}

            return View(supplier);
        }
        #endregion Get

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }

            //=>var result = supplierRepository.Post(supplier);
            /*=>if(result > 0)
                return RedirectToAction("Index", "supplier");*/

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44303/api/Supplier");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Supplier>("Supplier", supplier);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "supplier");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();
        }
        #endregion Create

        #region Edit
        [HttpGet("Supplier/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            //=>var supplier = supplierRepository.Get(id);
            //var supplier = myContext.Supplier.SingleOrDefault();
            //var supplier = myContext.Supplier.FirstOrDefault();
            //var supplier = myContext.Supplier.LastOrDefault();

            /*=>if(supplier != null)
            {
                return View(supplier);
            }<=*/

            Supplier supplier = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44303/api/");
                var responseTask = client.GetAsync("Supplier/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var parsedObject = JObject.Parse(readTask);
                    var dataOnly = parsedObject["data"].ToString();

                    supplier = JsonConvert.DeserializeObject<Supplier>(dataOnly);
                }
                else
                {
                    //supplier = Enumerable.Empty<Supplier>();

                    ModelState.AddModelError(string.Empty, "Server error. please contact administrator yg.");
                }
            }

            return View(supplier);

            //=>return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }

            //=>int result = supplierRepository.Put(supplier);
            /*=>if (result > 0)
                return RedirectToAction("Index", "Supplier");<=*/

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44303/api/Supplier");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Supplier>("Supplier", supplier);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "supplier");
                }
            }

            return View(supplier);

            //return View();
        }
        #endregion Edit

        #region Delete
        [HttpGet("Supplier/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            //=>var supplier = supplierRepository.Get(id);

            /*=>if (supplier != null)
            {
                return View(supplier);
            }<=*/

            Supplier supplier = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44303/api/");
                var responseTask = client.GetAsync("Supplier/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var parsedObject = JObject.Parse(readTask);
                    var dataOnly = parsedObject["data"].ToString();

                    supplier = JsonConvert.DeserializeObject<Supplier>(dataOnly);
                }
                else
                {
                    //supplier = Enumerable.Empty<Supplier>();

                    ModelState.AddModelError(string.Empty, "Server error. please contact administrator yg.");
                }
            }

            return View(supplier);

            //=>return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Supplier supplier)
        {
            //myContext.Supplier.Remove(supplier);
            //=>int result = supplierRepository.Delete(supplier);
            /*=>if (result > 0)
                return RedirectToAction("Index", "Supplier");<=*/

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri("https://localhost:44303/api/Supplier"),
                    Content = new StringContent(JsonConvert.SerializeObject(supplier), Encoding.UTF8, "application/json")
                };

                var response = client.SendAsync(request);
                response.Wait();
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "supplier");
                }
            }

            return View(supplier);
            //return View();
        }
        #endregion Delete
    }
}
