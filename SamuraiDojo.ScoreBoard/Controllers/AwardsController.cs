using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SamuraiDojo.Attributes.Bonus;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class AwardsController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Type[] awardTypes = ReflectionUtility.GetSubTypes<BonusPointsAttribute>("SamuraiDojo");
            List<IBonusPointsAttribute> awards = new List<IBonusPointsAttribute>();

            foreach (Type type in awardTypes)
            {
                IBonusPointsAttribute award = (BonusPointsAttribute)ReflectionUtility.GetInstance(type);
                awards.Add(award);
            }

            return Request.CreateResponse(HttpStatusCode.OK, awards);
        }
    }
}