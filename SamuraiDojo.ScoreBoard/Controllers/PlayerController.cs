using System.Net;
using System.Net.Http;
using System.Web.Http;
using SamuraiDojo.Stats;
using SamuraiDojo.ScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;

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
            return Request.CreateResponse(HttpStatusCode.OK, players);
        }
        
        private PlayerStats GetPlayer(string playerName)
        {
            PlayerStats player = ScoreKeeper.GetPlayer(playerName);
            if (player != null)
            {
                player.Username = playerName;
                player.ChallengesCompleted = player.PointsByChallenge.Keys.Count;
                player.Rank = CalculateRank(player);
            }

            return player;
        } 

        private int CalculateRank(PlayerStats player)
        {
            int rank = 1;
            foreach (KeyValuePair<string, PlayerStats> pair in ScoreKeeper.Players)
            {
                PlayerStats opponent = pair.Value;
                if (opponent.TotalPoints > player.TotalPoints)
                    rank++;
                else if (opponent.TotalPoints == player.TotalPoints)
                {
                    // If opponent has achieved as many points as you in fewer challenges, then he outranks you
                    if (player.PointsByChallenge.Keys.Count > opponent.PointsByChallenge.Keys.Count)
                        rank++;
                    else if (player.SenseiCount > opponent.SenseiCount)
                        rank++;
                }
            }

            return rank;
        }
    }
}