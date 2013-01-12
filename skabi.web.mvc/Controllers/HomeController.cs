using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using skabi.web.mvc.Models;

namespace skabi.web.mvc.Controllers
{
    public class HomeController : Controller
    {
        efrpdbEntities3 db = new efrpdbEntities3();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            ViewBag.ModelNews = db.news;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
