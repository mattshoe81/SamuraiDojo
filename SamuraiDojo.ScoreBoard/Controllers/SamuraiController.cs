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
    }
}