using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamuraiDojo.ScoreBoard.Metrics
{
    public class LogMetricsAttribute : ActionFilterAttribute
    {
        private const string SESSION_KEY = "session_key_samurai_dojo";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            Session session = Metrics.MetricsRepo.RegisterSession(filterContext.HttpContext);
            session.PageLoads.Add(new Page
            {
                Name = filterContext.HttpContext.Request.Url.LocalPath
            });
            filterContext.HttpContext.Session.Add(SESSION_KEY, string.Empty);
        }
    }
}