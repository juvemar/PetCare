namespace PetCare.Web
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AutoMapperConfig.Execute();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            if (arg.Equals("User", StringComparison.InvariantCultureIgnoreCase))
            {
                var user = context.User.Identity.Name; // TODO here you have to pick an unique identifier from the current user identity
                return string.Format("{0}@{1}", user, "Same User");
            }

            return base.GetVaryByCustomString(context, arg);
        }
    }
}
