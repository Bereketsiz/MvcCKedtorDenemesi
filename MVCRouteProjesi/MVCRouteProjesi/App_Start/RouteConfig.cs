using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCRouteProjesi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "IndexRoute",
                url: "Ana-Sayfa/Site-Ana-Sayfasi/Urunler-Sayfasi",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "ContactRoute",
                url: "İletisim-Bilgileri/İletisim-Sayfasi/Musteri-Iletisimi",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "AboutRoute",
                url: "Yardim-Düzenle/Yardime-Sayfasi/Yardim-Duzenleme-Sayfasi",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
