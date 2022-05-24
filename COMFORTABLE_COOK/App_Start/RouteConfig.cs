using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace COMFORTABLE_COOK
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Usuario",
                url: "Usuario",
                defaults: new { controller = "UsuarioController", action = "Registrar" }
            );

            routes.MapRoute(
                name: "Recetas",
                url: "Recetas",
                defaults: new { controller = "RecetasController", action = "Index" }
            );
            routes.MapRoute(
                name: "Favoritas",
                url: "Recetas",
                defaults: new { controller = "RecetasController", action = "Favoritas" }
            );
        }
    }
}
