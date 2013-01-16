using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using skabi.common.Services;
using skabi.common.ViewModels;

namespace skabi.web.mvc4.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _rpdbService;

        public NewsController(INewsService newsService)
        {
            this._rpdbService = newsService;
        }


        //
        // GET: /Home/
        public ActionResult Index()
        {
            
            return View();
        }

    }
}
