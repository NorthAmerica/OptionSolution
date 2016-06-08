﻿using OP.Web.Ninject;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OP.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new
                         NinjectControllerFactory());
            
        }
    }
}
