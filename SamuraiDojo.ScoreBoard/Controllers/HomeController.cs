using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SamuraiDojo.IOC;
using SamuraiDojo.IOC.Interfaces;
using SamuraiDojo.Repositories;
using SamuraiDojo.ScoreBoard.Metrics;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    [LogMetrics]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.CurrentBattle = Factory.Get<IBattleRepository>().CurrentBattle();
            return View();
        }
    }
}