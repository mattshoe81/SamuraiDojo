using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class SamuraiController : Controller
    {
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
    }
}