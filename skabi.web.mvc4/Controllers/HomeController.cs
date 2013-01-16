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
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService, IRpdbService rpdbService)
        {
            this._rpdbService = rpdbService;
            this._newsService = newsService;
        }


        //
        // GET: /Home/
        public ActionResult Index()
        {
            var brands = _rpdbService.GetAllCarbrands();
            var homeViewModel = new HomeViewModel();
            homeViewModel.Carbrands = brands;
            homeViewModel.News = _newsService.GetTopFiveNews();
            homeViewModel.LatestProposals = _rpdbService.GetLatestProposals(4);
            return View(homeViewModel);
        }

    }
}
