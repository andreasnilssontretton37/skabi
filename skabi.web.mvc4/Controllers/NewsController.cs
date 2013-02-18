using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using skabi.common.Services;
using skabi.common.ViewModels;
using skabi.data.DomainModel;

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

        public ActionResult Put(News item)
        {
            try
            {
                var newItem = this._rpdbService.Add(item);
                return new JsonResult
                    {
                        Data = newItem
                    };
            }
            catch (ArgumentNullException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
        }
    }
}
