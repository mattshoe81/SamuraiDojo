using System.Net;
using System.Net.Http;
using System.Web.Http;
using SamuraiDojo.Stats;
using SamuraiDojo.ScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Linq;

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

            PlayerStats player = GetPlayer(playerName);
            return Request.CreateResponse(HttpStatusCode.OK, player);
        }
        
        [HttpGet]
        [Route("api/Player/All")]
        public HttpResponseMessage All()
        {
            List<PlayerStats> players = new List<PlayerStats>();
            foreach (KeyValuePair<string, PlayerStats> pair in ScoreKeeper.Players)
            {
                PlayerStats player = GetPlayer(pair.Key);
                if (player != null) 
                    players.Add(player);
            }
            players.Sort();

            return Request.CreateResponse(HttpStatusCode.OK, players);
        }
        
        private PlayerStats GetPlayer(string playerName)
        {
            PlayerStats player = ScoreKeeper.GetPlayer(playerName);
            return player;
        } 
    }
}