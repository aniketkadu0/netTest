using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeDemo.Models;

namespace EFCodeDemo.Controllers
{
    public class Home2Controller : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Insert(Student std)
        {
            DacDbContext db = new DacDbContext();
            db.students.Add(std);
            db.SaveChanges();
            return Content("Successfully Inserted");
        }
    }
}