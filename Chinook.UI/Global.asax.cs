﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Chinook.Data.DbCommandProvider;
using Chinook.Data.Repository;
using Chinook.Data.SqlDbCommandProvider;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace Chinook.Web.UI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            
            container.Register<IDbAlbumCommandProvider, SqlDbAlbumCommandProvider>();
            container.Register<IDbArtistCommandProvider, SqlDbArtistCommandProvider>();
            container.Register<IAlbumRepository, DbAlbumRepository>();
            container.Register<IArtistRepository, DbArtistRepository>();
           
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
