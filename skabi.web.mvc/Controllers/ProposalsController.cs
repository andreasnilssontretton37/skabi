using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using skabi.web.mvc.Models;
using System.Data.Objects.SqlClient;

namespace skabi.web.mvc.Controllers
{
    public class ProposalsController : Controller
    {
        efrpdbEntities3 db = new efrpdbEntities3();
        //
        // GET: /Proposal/

        public ActionResult Index()
        {
            return View(db.carbrands);
        }

        public ActionResult GetLatestProposals()
        {
            return View("LatestProposals", db.carmodeltypes_proposals);
        }


        public JsonResult GetCarModels(int id)
        {
            var result = from carmodel in db.carmodels
                         where carmodel.carbrand_id.Equals(id)
                         select new
                         {
                             Name = carmodel.model_name,
                             ID = carmodel.id
                         };
            
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarModelTypes(int id)
        {
            var result = from cmt in db.carmodeltypes.AsEnumerable()
                         where cmt.carmodel_id.Equals(id)
                         select new
                         {
                             ID = cmt.id,
                             //Name = new Func<carmodeltype, string>(GetConcatenatedWheelbaseAndCubic).Invoke(cmt)
                             Name = string.Format("Axelavstånd {0} mm {1} m3", cmt.wheelbase, cmt.cubic)

                         };

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCarBrand(string name)
        {
            carbrand brand = db.carbrands.Create();
            brand.brand_name = "lala";
            db.carbrands.Add(brand);
            db.SaveChanges();

            var result = from carbrand in db.carbrands                         
                         select new
                         {
                             Name = carbrand.brand_name
                         };

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCarBrand(string brandname)
        {
           
            carbrand brand = db.carbrands.First(b => b.brand_name == "lala" ? true : false);
            db.carbrands.Remove(brand);
            db.SaveChanges();

            var result = from carbrand in db.carbrands
                         select new
                         {
                             Name = carbrand.brand_name
                         };

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Proposal/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Proposal/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Proposal/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Proposal/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Proposal/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Proposal/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Proposal/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
