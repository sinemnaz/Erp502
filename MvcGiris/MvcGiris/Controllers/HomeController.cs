using MvcGiris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcGiris.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var numbers = new List<string>();
            for (int i = 1; i <=10; i++)
            {
                numbers.Add(i.ToString());
            }

            ViewBag.unit = new SelectList(numbers);
            ViewBag.deneme = "Sinem";
            ViewBag.tarih = DateTime.Now.Year;

            ViewData["mesaj"] = "Asp.Net MVC";
            TempData["mesaj"] = "Asp.Net Core MVC";


            return View();
        }

        [HttpGet]
        public ActionResult Listele()
        {
            var emp = db.Employees.ToList();
            return View(emp);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employees.FirstOrDefault(x=>x.Id==id);
            if(emp==null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                //employees[emp.Id-1] = emp;
                return RedirectToAction("Listele");
            }
            return View(emp);
        }

        public ActionResult Create()
        {
            var emp = new Employee();
            var sonid = (from s in db.Employees select s).OrderByDescending(x => x.Id).First().Id;
            TempData["sonId"] = sonid + 1;
            return View(emp);
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                emp.Id = (int)TempData["sonId"];
                db.Employees.Add(emp);
                return RedirectToAction("Listele");
            }
            return View(emp);
        }
    }
}