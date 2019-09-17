using System.Web.Mvc;
using SamuraiDojo.Interfaces;
using SamuraiDojo.IoC;
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