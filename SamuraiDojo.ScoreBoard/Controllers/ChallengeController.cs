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
    public class ChallengeController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            ChallengeResults challenge = ChallengeRepository.CurrentChallenge();

            return Request.CreateResponse(HttpStatusCode.OK, challenge);
        }

        [HttpGet]
        [Route("api/Challenge/All")]
        public HttpResponseMessage All()
        {
            List<ChallengeResults> challenges = ChallengeRepository.GetAllChallengeResults();

            return Request.CreateResponse(HttpStatusCode.OK, challenges);
        }
    }
}