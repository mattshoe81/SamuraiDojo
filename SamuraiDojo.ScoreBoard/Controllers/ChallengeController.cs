using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SamuraiDojo.Attributes;
using SamuraiDojo.Stats;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class ChallengeController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Type currentChallenge = ScoreKeeper.CurrentChallenge;
            ChallengeAttribute challengeAttribute = AttributeUtility.GetAttribute<ChallengeAttribute>(currentChallenge);

            return Request.CreateResponse(HttpStatusCode.OK, challengeAttribute);
        }
    }
}