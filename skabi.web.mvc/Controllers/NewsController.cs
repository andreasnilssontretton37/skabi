using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using skabi.web.mvc.Models;

namespace skabi.web.mvc.Controllers
{ 
    public class NewsController : Controller
    {
        private efrpdbEntities3 db = new efrpdbEntities3();

        //
        // GET: /News/

        public ViewResult Index()
        {
            //return View(db.news.ToList());
            return View("Index", db.news);
        }

        public ActionResult Latest()
        {
            return View("Latest", db.news);
        }

        //
        // GET: /News/Details/5

        public ViewResult Details(int id)
        {
            news news = db.news.Find(id);
            return View(news);
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /News/Create

        [HttpPost]
        public ActionResult Create(news news)
        {
            if (ModelState.IsValid)
            {
                db.news.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(news);
        }
        
        //
        // GET: /News/Edit/5
 
        public ActionResult Edit(int id)
        {
            news news = db.news.Find(id);
            return View(news);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(news news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        //
        // GET: /News/Delete/5
 
        public ActionResult Delete(int id)
        {
            news news = db.news.Find(id);
            return View(news);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            news news = db.news.Find(id);
            db.news.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}