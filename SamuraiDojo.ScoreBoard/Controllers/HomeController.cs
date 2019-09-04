using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Repositories;
using SamuraiDojo.ScoreBoard.Metrics;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    [LogMetrics]
    public class HomeController : Controller
    {
        private IBattleRepository battleRepository;

        public HomeController()
        {
            battleRepository = Factory.Get<IBattleRepository>();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.CurrentBattle = battleRepository.CurrentBattle();
            return View();
        }
    }
}