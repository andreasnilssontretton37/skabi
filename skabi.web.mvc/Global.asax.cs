using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using skabi.web.mvc.Models;
using System.Web.Security;

namespace skabi.web.mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Proposals", // Route name
                "{controller}/{action}/{brandname}", // URL with parameters
                new
                {
                    Controller = "Proposals",
                    action = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );


            /*
            routes.MapRoute(
                "Proposals", // Route name
                "{controller}/{action}/{brandname}/{modelid}/{modeltypeid}", // URL with parameters
                new {
                    controller = "Proposals",   
                    action = UrlParameter.Optional,
                    brandname = UrlParameter.Optional,
                    modelid = UrlParameter.Optional,
                    modeltypeid = UrlParameter.Optional
                }           
            );
            */
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


            AccountRepository repo = new AccountRepository();
            ((AccountMembershipProvider)Membership.Provider).AccountRepository = repo;
            ((AccountRoleProvider)Roles.Provider).AccountRepository = repo;
        }
    }
}