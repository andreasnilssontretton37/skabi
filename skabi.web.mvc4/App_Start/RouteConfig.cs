using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace skabi.web.mvc4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
                name: "Carbrands",
                url: "proposals",
                defaults: new { controller = "Proposals", action = "ListCarbrands" }
            );
             

           routes.MapRoute(
               name: "ListCarmodelsFromCarbrandId",
               url: "proposals/{carbrandId}",
               defaults: new { controller = "Proposals", action = "ListCarmodelsFromCarbrandId", carbrandId = UrlParameter.Optional },
               constraints: new { carbrandId = @"\d+" }
           );

           routes.MapRoute(
             name: "ListCarmodelsFromCarbrandName",
             url: "proposals/{carbrandName}",
             defaults: new { controller = "Proposals", action = "ListCarmodelsFromCarbrandName", carbrandName = UrlParameter.Optional },
             constraints: new { carbrandName = @"\w+" }
            );

           routes.MapRoute(
              name: "ListCarmodelTypesFromCarmodelId",
              url: "proposals/{carbrandId}/{carmodelId}",
              defaults: new { controller = "Proposals", action = "ListCarmodelTypesFromCarmodelId", carmodelId = UrlParameter.Optional },
              constraints: new { carmodelId = @"\d+" }
           );

           routes.MapRoute(
              name: "ListCarmodelTypesFromCarmodelName",
              url: "proposals/{carbrandName}/{carmodelName}",
              defaults: new { controller = "Proposals", action = "ListCarmodelTypesFromCarmodelName", carmodelId = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}