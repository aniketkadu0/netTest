using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBDemo.Models;

namespace EFDBDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /*public ActionResult Index()
        {
            SampleDBEntities db = new SampleDBEntities();
            List<Employee> employee = db.Employees.ToList();
            return View(employee);
        }*/

        public ActionResult Index(string search="")
        {
            SampleDBEntities db = new SampleDBEntities();
            //List<Employee> employee = db.Employees.ToList();
            ViewBag.search = search;
            List<Employee> employee = db.Employees.Where(temp=>temp.EmpName.Contains(search)).ToList();
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }
        //Add record
        [HttpPost]
        public ActionResult Create(Employee ep)
        {
            SampleDBEntities db = new SampleDBEntities();
            db.Employees.Add(ep);
            db.SaveChanges();
            return View();
        }


        public ActionResult Update(int id)
        {
            SampleDBEntities db = new SampleDBEntities();
            Employee ep = db.Employees.Where(temp => temp.EmpId == id).FirstOrDefault();
            return View(ep);
        }

        [HttpPost]
        public ActionResult Update(Employee ep)
        {
            SampleDBEntities db = new SampleDBEntities();
            Employee emp = db.Employees.Where(temp => temp.EmpId == ep.EmpId).FirstOrDefault();
            emp.EmpName = ep.EmpName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            SampleDBEntities db = new SampleDBEntities();
            Employee ep = db.Employees.Where(temp => temp.EmpId == id).FirstOrDefault();
            return View(ep);
        }
        [HttpPost]
        public ActionResult Delete(int id ,Employee emp)
        {

            SampleDBEntities db = new SampleDBEntities();
            Employee ep = db.Employees.Where(temp => temp.EmpId == id).FirstOrDefault();
            db.Employees.Remove(ep);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}