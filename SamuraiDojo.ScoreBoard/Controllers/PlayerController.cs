using System.Net;
using System.Net.Http;
using System.Web.Http;
using SamuraiDojo.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Linq;
using SamuraiDojo.Models;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.IoC;
using SamuraiDojo.Interfaces;
using SamuraiDojo.Services;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class PlayerController : BaseApiController
    {
        private IPlayerService playerService;

        public PlayerController()
        {
            playerService = Factory.Get<IPlayerService>();
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Get(null);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get(string name)
        {
            string playerName = name;
            if (playerName == null)
                playerName = GetCurrentUsername();

            IPlayer player = playerService.GetPlayer(name);

            return Request.CreateResponse(HttpStatusCode.OK, player);
        }
        
        [HttpGet]
        [Route("api/Player/All")]
        public HttpResponseMessage All()
        {
            List<IPlayer> players = playerService.GetAllPlayers();

            return Request.CreateResponse(HttpStatusCode.OK, players);
        }
    }
}