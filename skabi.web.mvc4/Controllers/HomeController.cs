using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using skabi.common.Services;
using skabi.common.ViewModels;

namespace skabi.web.mvc4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRpdbService _rpdbService;

        public HomeController(IRpdbService rpdbService)
        {
            this._rpdbService = rpdbService;
        }


        //
        // GET: /Home/
        public ActionResult Index()
        {
            var brands = _rpdbService.GetAllCarbrands();
            var homeViewModel = new HomeViewModel();
            homeViewModel.Carbrands = brands;
            return View(homeViewModel);
        }

    }
}
