using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using skabi.common.Services;

namespace skabi.web.mvc4.Controllers
{
    public class ProposalsController : Controller
    {
        private readonly IRpdbService _rpdbService;

        public ProposalsController(IRpdbService rpdbService)
        {
            this._rpdbService = rpdbService;
        }


        //
        // GET: /Home/
        public ActionResult Index()
        {
            var brands = _rpdbService.GetAllCarbrands();
            return View();
        }

    }
}
