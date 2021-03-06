﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using Futbol.Models;
using Futbol.ViewModels;

namespace Futbol
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
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Equipos", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            Database.SetInitializer<FutbolContext>(new DropCreateDatabaseIfModelChanges<FutbolContext>());
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            AutoMapperConfiguration.Configure();
        }
    }

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {

            Mapper.CreateMap<Jugador, JugadorListViewModels>();
            Mapper.CreateMap<JugadorListViewModels, Jugador>();

        }
    }
}