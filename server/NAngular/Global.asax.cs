using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NAngular.App_Start;

namespace NAngular
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UnityConfig.GetConfiguredContainer();

            // Do not add "X-AspNetMvc-Version" to the response headers
            MvcHandler.DisableMvcResponseHeader = true;
        }

        protected void Application_EndRequest()
        {
            // Remove disclosures like "Microsoft-IIS/10.0".
            var headers = HttpContext.Current.Response.Headers;
            if (headers.AllKeys.Contains("Server"))
            {
                // This applies to ASP; static files served by IIS may still have a Server response header.
                headers.Remove("Server");
            }
            if (headers.AllKeys.Contains("X-AspNet-Version"))
            {
                // This is never reached if httpRuntime enableVersionHeader=false
                headers.Remove("X-AspNet-Version");
            }
        }
    }
}
