using PeopleSearchApp.Models;
using PeopleSearchApp.Models.DAL;
using System;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace PeopleSearchApp.Controllers
{
    public class HomeController : Controller
    {
        PersonContext context = new PersonContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public JsonResult SearchName(string id)
        {
            var all = context.Person.Select(e => e);
            if (!String.IsNullOrEmpty(id))
            {
                all = all.Where(e => e.FirstName.Contains(id) || e.LastName.Contains(id));
            }
            return Json(all.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DelayedSearch(string id)
        {
            var all = context.Person.Select(e => e);
            Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(3, 4)));
            return Json(all.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreatePerson(Person p)
        {
            ViewBag.Title = "Create New";
            return View();
        }

        public ActionResult SavePerson(Person p)
        {
            new PeopleController().PostPerson(p);
            return RedirectToAction("Index");
        }
    }
}
