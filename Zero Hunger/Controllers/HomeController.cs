using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Zero_Hunger.EF;
using Zero_Hunger.EF.Models;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Collect()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Collect(Collect model)
        {
            var db = new ZHContext();
            db.Collects.Add(model);
            db.SaveChanges();
            TempData["Msg"] = "Your Collect Requested Successfully";
            TempData["Color"] = "alert-success";
            return Index();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Collection()
        {
            if (Session["admin"] != null)
            {
                var db = new ZHContext();
                var collects = db.Collects.ToList();
                return View(collects);
            }
            else 
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {           
            ZHContext db = new ZHContext();
            var admin = (from a in db.NGOs
                        where a.Username.Equals(model.Username)
                        && a.Password.Equals(model.Password)
                        select a).SingleOrDefault();

            if (admin != null)
            {
                Session["admin"] = admin;
                return RedirectToAction("Collection");
            }

            else
            {
                TempData["Msg"] = "Please Enter Correct Username & Password";
                TempData["Color"] = "alert-danger";
                return View();
            }
        }

        public ActionResult AssignEmployee(int id)
        {
            ZHContext db = new ZHContext();
            Session["id"] = id;
            db.SaveChanges();
            return RedirectToAction("AssignEmployees");
        }

        [HttpGet]
        public ActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Employee(Employee model, ActiveEmployee model1)
        {
            var db = new ZHContext();
            db.Employees.Add(model);
            db.ActiveEmployees.Add(model1);
            db.SaveChanges();
            TempData["Msg"] = "Employee Registered Successfully";
            TempData["Color"] = "alert-success";
            return RedirectToAction("Employee");
        }

        public ActionResult Employees()
        {
            var db = new ZHContext();
            var employees = db.Employees.ToList();
            return View(employees);
        }

        public ActionResult AssignEmployees()
        {
            var db = new ZHContext();
            var activeEmployees = db.ActiveEmployees.ToList();
            return View(activeEmployees);
        }

        public ActionResult Assign(int id)
        {
            ZHContext db = new ZHContext();
            var collect = db.Collects.Find((int)Session["id"]);
            var activeEmployee = db.ActiveEmployees.Find(id);
            CollectDetail collectDetail = new CollectDetail
            {
                RestaurantName = collect.RestaurantName,
                Item = collect.Item,
                Quantity = collect.Quantity,
                Preservation_time = collect.Preservation_time,
                EmployeeName = activeEmployee.Name
            };
            db.CollectDetails.Add(collectDetail);
            db.Collects.Remove(collect);
            db.ActiveEmployees.Remove(activeEmployee);
            db.SaveChanges();
            return RedirectToAction("Collection");
        }

        [HttpGet]
        public ActionResult MakeActive(int id)
        {
            ZHContext db = new ZHContext();
            var activeEmployee = db.ActiveEmployees.Find(id);

            if (activeEmployee == null) 
            {
                var employee = db.Employees.Find(id);
                return View(employee);
            }
            return RedirectToAction("Collection");
        }

        [HttpPost]
        public ActionResult MakeActive(ActiveEmployee model)
        {
            var db = new ZHContext();
            db.ActiveEmployees.Add(model);
            db.SaveChanges();
            return RedirectToAction("Collection");
        }

        public ActionResult CollectDetails()
        {
            var db = new ZHContext();
            var collectDetails = db.CollectDetails.ToList();
            return View(collectDetails);
        }

        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Index");
        }
    }
}