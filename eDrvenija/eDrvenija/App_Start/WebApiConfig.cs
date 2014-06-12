using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Routing;
using eDrvenija.eDrvenija;

namespace eDrvenija
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            /*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ).RouteHandler = new MyHttpControllerRouteHandler();

            // CUSTOM ROUTES

            #region Korisnik


            config.Routes.MapHttpRoute(
                name: "DajBrojAktivnihKorisnikaByOcjena",
                routeTemplate: "Korisnik/DajBrojAktivnihKorisnikaByOcjena/{ocjena}",
                defaults: new { controller = "KorisniciApi", Action = "DajBrojAktivnihKorisnikaByOcjena", ocjena = RouteParameter.Optional },
                constraints: new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Get) }
            );


            config.Routes.MapHttpRoute(
                name: "DajBrojNeaktivnihKorisnikaByOcjena",
                routeTemplate: "Korisnik/DajBrojNeaktivnihKorisnikaByOcjena/{ocjena}",
                defaults: new { controller = "KorisniciApi", Action = "DajBrojNeaktivnihKorisnikaByOcjena", ocjena = RouteParameter.Optional },
                constraints: new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Get) }
            );


            config.Routes.MapHttpRoute(
                name: "DajBrojNovihKorisnikaByBrojDana",
                routeTemplate: "Korisnik/DajBrojNovihKorisnikaByBrojDana/{brojDana}",
                defaults: new { controller = "KorisniciApi", Action = "DajBrojNovihKorisnikaByBrojDana", brojDana = RouteParameter.Optional },
                constraints: new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Get) }
            );


            config.Routes.MapHttpRoute(
                name: "GetKorisniciByUsername",
                routeTemplate: "Korisnik/GetkorisniciByUsername/{user}",
                defaults: new { controller = "Korisnik", Action = "GetkorisniciByUsername", user = RouteParameter.Optional },
                constraints: new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "GetKorisnikByEmail",
                routeTemplate: "Korisnik/GetkorisniciByEmail/{email}",
                defaults: new { controller = "Korisnik", Action = "GetkorisniciByEmail", email = RouteParameter.Optional },
                constraints: new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "Login",
                routeTemplate: "Korisnik/Login",
                defaults: new { controller = "Korisnik", Action = "Login"},
                constraints: new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                name: "Logout",
                routeTemplate: "Korisnik/Logout/{id}",
                defaults: new { controller = "Korisnik", Action = "Logout", id = RouteParameter.Optional },
                constraints: new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Get) }
            );

            #endregion

            #region Oglasi

            /*config.Routes.MapHttpRoute(
                name: "DajOglasePoKategoriji",
                routeTemplate: "Oglasi/DajOglasePoKategoriji/{id}",
                defaults: new { controller = "OglasiApi", Action = "DajOglasePoKategoriji", id = RouteParameter.Optional },
                constraints: new { httpMethod = new System.Web.Http.Routing.HttpMethodConstraint(HttpMethod.Get) }
            );*/

            #endregion

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
