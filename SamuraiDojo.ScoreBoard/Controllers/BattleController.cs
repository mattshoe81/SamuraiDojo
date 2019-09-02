﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SamuraiDojo.Attributes;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Models;
using SamuraiDojo.Repositories;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class BattleController : BaseApiController
    {
        private IBattleRepository battleRepository;

        public BattleController()
        {
            battleRepository = Factory.Get<IBattleRepository>();
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            IBattleOutcome battle = battleRepository.CurrentBattle();

            return Request.CreateResponse(HttpStatusCode.OK, battle);
        }

        [HttpGet]
        [Route("api/Battle/All")]
        public HttpResponseMessage All()
        {
            List<IBattleOutcome> battles = battleRepository.GetAllBattleOutcomes();

            return Request.CreateResponse(HttpStatusCode.OK, battles);
        }
    }
}