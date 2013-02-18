using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

        public JsonResult ListCarbrands() //(int? carbrandId)
        {
            
//            if (carbrandId.HasValue)
//            {
//                return new JsonResult
//                {
//                    Data = from carbrand in this._rpdbService.GetAllCarbrands()
//                           where carbrand.CarbrandID == carbrandId
//                           select new
//                           {
//                               carbrand.CarbrandID,
//                               carbrand.Name,
//                               /*
//                               Carmodels = from carmodel in carbrand.Carmodels
//                                           select new
//                                               {
//                                                   carmodel.CarmodelID,
//                                                   carmodel.Name
//                                               },
//                                */
//                                   },
//                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
//                };
//            }
            
            return new JsonResult
                {
                    Data = from carbrand in this._rpdbService.GetAllCarbrands()
                           select new
                                   {
                                       carbrand.CarbrandID,
                                       carbrand.Name,
                                       /*
                                       Carmodels = from carmodel in carbrand.Carmodels
                                                   select new
                                                   {
                                                       carmodel.CarmodelID,
                                                       carmodel.Name
                                                   },
                                        */

                                   },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }

        
        public JsonResult ListCarmodelsFromCarbrandId(int? carbrandId)
        {
            
            var data = from carmodel in this._rpdbService.GetCarbrandModels(carbrandId.Value)
                       select new
                           {
                               CarbrandName = carmodel.Carbrand.Name,
                               carmodel.CarmodelID,
                               carmodel.Name
                           };
            
            return new JsonResult
                {
                    Data = data,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    
                };
        }

        public JsonResult ListCarmodelsFromCarbrandName(string carbrandName)
        {
            

            var data = from carmodel in this._rpdbService.GetCarbrandModels(carbrandName)
                       select new
                       {
                           CarbrandName = carmodel.Carbrand.Name,
                           carmodel.CarmodelID,
                           carmodel.Name
                       };
            
       
            return new JsonResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet

            };
        }

        public JsonResult ListCarmodelTypesFromCarmodelId(int carmodelId)
        {
            return new JsonResult
                {
                    Data = from carmodelType in this._rpdbService.GetCarmodelTypesForModel(carmodelId)
                           where carmodelType.CarmodelID == carmodelId
                           select new
                               {
                                   carmodelType.Wheelbase,
                                   carmodelType.Cubic,
                                   carmodelType.CarmodelTypeID
                               },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }

        public JsonResult ListCarmodelTypesFromCarmodelName(string carmodelName)
        {
            return new JsonResult
            {
                Data = from carmodelType in this._rpdbService.GetCarmodelTypesForModel(carmodelName)
                       where carmodelType.Carmodel.Name.ToLower().Replace(" ", string.Empty) == carmodelName.ToLower().Replace(" ", string.Empty)
                       select new
                       {
                           carmodelType.Wheelbase,
                           carmodelType.Cubic,
                           carmodelType.CarmodelTypeID
                       },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}
