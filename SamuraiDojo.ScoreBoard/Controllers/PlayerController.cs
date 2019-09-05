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

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class PlayerController : BaseApiController
    {
        private IPlayerRepository playerRepository;

        public PlayerController()
        {
            playerRepository = Factory.Get<IPlayerRepository>();
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

            IPlayer player = GetPlayer(playerName);
            return Request.CreateResponse(HttpStatusCode.OK, player);
        }
        
        [HttpGet]
        [Route("api/Player/All")]
        public HttpResponseMessage All()
        {
            List<IPlayer> players = new List<IPlayer>();
            foreach (KeyValuePair<string, IPlayer> pair in playerRepository.Players)
            {
                IPlayer player = GetPlayer(pair.Key);
                if (player != null) 
                    players.Add(player);
            }
            players.Sort();

            return Request.CreateResponse(HttpStatusCode.OK, players);
        }
        
        private IPlayer GetPlayer(string playerName)
        {
            IPlayer player = playerRepository.GetPlayer(playerName);
            return player;
        } 
    }
}