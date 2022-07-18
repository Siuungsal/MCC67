using MCC67.Context;
using MCC67.Models;
using MCC67.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Encodings.Web;

namespace MCC67.Controllers
{
    public class ProdukController : Controller
    {
        //MyContext myContext;
        
        ProdukRepository produkRepository;
        SupplierRepository supplierRepository;

        public ProdukController(ProdukRepository produkRepository, SupplierRepository supplierRepository)
        {
            this.produkRepository = produkRepository;
            this.supplierRepository = supplierRepository;
        }

        #region Get
        [HttpGet]
        public IActionResult Index()
        {
            //List<Produk> produk = myContext.Produk.ToList();
            //var produk = myContext.Produk.ToList();
            //=>var produk = produkRepository.Get();
            //var produk = myContext.Produk.Where(x => x.Name == "Indofood").ToList();
            /*=>if (produk.Count() != 0)
            {
                return View(produk);
            }<=*/

            IEnumerable<Produk> produk = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44303/api/");
                var responseTask = client.GetAsync("Produk");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<IList<Produk>>();
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var parsedObject = JObject.Parse(readTask);
                    var dataOnly = parsedObject["data"].ToString();
                    //readTask.Wait();

                    //produk = readTask.Result;
                    produk = JsonConvert.DeserializeObject<List<Produk>>(dataOnly);
                }
                else
                {
                    produk = Enumerable.Empty<Produk>();

                    ModelState.AddModelError(string.Empty, "Server error. please contact administrator yg.");
                }
            }

            return View(produk);
        }
        #endregion Get

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            //var supplier = new SelectList(myContext.Supplier.ToList(), "Id", "Name");
            var supplier = new SelectList(supplierRepository.Get(), "Id", "Name");
            if (supplier.Count() > 0)
            {
                ViewBag.Supplier = supplier;
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produk produk)
        {
            if (!ModelState.IsValid)
            {
                return Create();
            }

            //myContext.Produk.Add(produk);
            // INSERT INTO PRODUK VALUE (produk)
            int result = produkRepository.Post(produk);
            if (result > 0)
                return RedirectToAction("Index", "Produk");
            return View();
        }
        #endregion Create

        #region Edit
        [HttpGet("Produk/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            //var supplier = new SelectList(myContext.Supplier.ToList(), "Id", "Name");
            var supplier = new SelectList(supplierRepository.Get(), "Id", "Name");
            if (supplier.Count() > 0)
            {
                ViewBag.Supplier = supplier;
            }

            //var produk = myContext.Produk.Find(id);
            var produk = produkRepository.Get(id);
            if (produk != null)
            {
                return View(produk);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produk produk)
        {
            if (!ModelState.IsValid)
            {
                return Edit(produk.Id);
            }

            //myContext.Entry(produk).State = EntityState.Modified;
            //int result = myContext.SaveChanges();
            int result = produkRepository.Put(produk);
            if (result > 0)
                return RedirectToAction("Index", "Produk");
            return View();
        }
        #endregion Edit

        #region Delete
        [HttpGet("Produk/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            //var produk = myContext.Produk.Find(id);
            var produk = produkRepository.Get(id);

            if (produk != null)
            {
                return View(produk);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Produk produk)
        {
            //myContext.Entry(produk).State = EntityState.Deleted;
            //myContext.Produk.Remove(produk);
            //int result = myContext.SaveChanges();
            int result = produkRepository.Delete(produk);
            if (result > 0)
                return RedirectToAction("Index", "Produk");
            return View();
        }
        #endregion Delete

        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}
