using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SamuraiDojo.Attributes;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class BattleController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            BattleOutcome battle = BattleRepository.CurrentBattle();

            return Request.CreateResponse(HttpStatusCode.OK, battle);
        }

        [HttpGet]
        [Route("api/Battle/All")]
        public HttpResponseMessage All()
        {
            List<BattleOutcome> battles = BattleRepository.GetAllBattleOutcomes();

            return Request.CreateResponse(HttpStatusCode.OK, battles);
        }
    }
}