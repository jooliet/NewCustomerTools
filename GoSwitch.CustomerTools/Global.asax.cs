using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GoSwitch.CustomerTools.DAL;

namespace GoSwitch.CustomerTools
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private class HttpDataContextDataStore : IDataRepositoryStore
        {
            public object this[string key]
            {
                get { return HttpContext.Current.Items[key]; }
                set { HttpContext.Current.Items[key] = value; }
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DataRepositoryStore.CurrentDataStore = new HttpDataContextDataStore();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
