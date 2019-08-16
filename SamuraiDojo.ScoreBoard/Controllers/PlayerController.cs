using System.Net;
using System.Net.Http;
using System.Web.Http;
using SamuraiDojo.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Linq;
using SamuraiDojo.Models;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class PlayerController : BaseApiController
    {
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

            Player player = GetPlayer(playerName);
            return Request.CreateResponse(HttpStatusCode.OK, player);
        }
        
        [HttpGet]
        [Route("api/Player/All")]
        public HttpResponseMessage All()
        {
            List<Player> players = new List<Player>();
            foreach (KeyValuePair<string, Player> pair in PlayerRepository.Players)
            {
                Player player = GetPlayer(pair.Key);
                if (player != null) 
                    players.Add(player);
            }
            players.Sort();

            return Request.CreateResponse(HttpStatusCode.OK, players);
        }
        
        private Player GetPlayer(string playerName)
        {
            Player player = PlayerRepository.GetPlayer(playerName);
            return player;
        } 
    }
}