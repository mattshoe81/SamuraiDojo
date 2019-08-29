using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SamuraiDojo.ScoreBoard.Metrics;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    [LogMetrics]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}