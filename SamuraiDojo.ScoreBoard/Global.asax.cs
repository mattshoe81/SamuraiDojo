using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SamuraiDojo.IoC;
using SamuraiDojo.ScoreBoard.App_Start;
using SamuraiDojo.Scoring.Interfaces;

namespace SamuraiDojo.ScoreBoard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IoC.Dojector.BindAssembliesReflectively();

            // Kick off the reflective scoring system
            Factory.Get<IScoreKeeper>().Start();
        }
    }
}
