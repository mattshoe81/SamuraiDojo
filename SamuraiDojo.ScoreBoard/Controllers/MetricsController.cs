using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SamuraiDojo.ScoreBoard.Metrics;
using SamuraiDojo.ScoreBoard.Models;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    [LogMetrics]
    public class MetricsController : Controller
    {
        public ActionResult Overview()
        {
            ViewBag.Title = "Metrics Overview";
            OverviewViewModel model = new OverviewViewModel();
            model.Sessions = MetricsRepo.Sessions;
            model.Visitors = MetricsRepo.VisitorCount;
            
            foreach (Session session in model.Sessions)
            {
                foreach (Page pageLoad in session.PageLoads)
                {
                    if (!model.PageLoads.Any(page => page.Page.Equals(pageLoad)))
                        model.PageLoads.Add(new PageMetrics { Page = pageLoad, Loads = 1 });
                    else
                    {
                        PageMetrics page = model.PageLoads.Where(metric => metric.Page.Equals(pageLoad)).FirstOrDefault();
                        if (page != null)
                            page.Loads = ++page.Loads;
                    }
                }
            }
            
            return View(model);
        }

        public ActionResult SessionDetails(string id)
        {
            ViewBag.Title = "Metrics Overview";
            Session session = MetricsRepo.Sessions.Where(sess => id == sess.SessionID).FirstOrDefault();
            if (session == null)
                session = new Session();

            return View(session);
        }
    }
}