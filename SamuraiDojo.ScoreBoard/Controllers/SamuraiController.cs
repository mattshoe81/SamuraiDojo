using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Repositories;
using SamuraiDojo.ScoreBoard.Metrics;
using SamuraiDojo.ScoreBoard.Models;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    [LogMetrics]
    public class SamuraiController : Controller
    {
        private IBattleRepository battleRepository;

        public SamuraiController()
        {
            battleRepository = Factory.Get<IBattleRepository>();
        }

        public ActionResult MyProfile()
        {
            ViewBag.Title = "My Profile";
            return View();
        }

        public ActionResult Awards()
        {
            ViewBag.Title = "Awards";
            return View();
        }

        public ActionResult GettingStarted()
        {
            ViewBag.Title = "Getting Started";
            return View();
        }

        public ActionResult Scoring()
        {
            ViewBag.Title = "Scoring";
            return View();
        }

        public ActionResult Benchmarking()
        {
            ViewBag.Title = "Benchmarking";
            return View();
        }

        public ActionResult Sensei()
        {
            ViewBag.Title = "Sensei";
            return View();
        }

        public ActionResult History()
        {
            ViewBag.Title = "History";

            HistoryViewModel model = new HistoryViewModel();
            model.Battles = battleRepository.GetAllBattleOutcomes();
            model.Battles.OrderByDescending(battle => battle.Battle.Deadline).ToList();

            return View(model);
        }
    }
}