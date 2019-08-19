using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using SamuraiDojo.Attributes.Bonus;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class AwardsController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Type[] awardTypes = ReflectionUtility.GetSubTypes<BonusPointsAttribute>("SamuraiDojo");
            List<BonusPointsAttribute> awards = new List<BonusPointsAttribute>();

            foreach (Type type in awardTypes)
            {
                BonusPointsAttribute award = (BonusPointsAttribute)ReflectionUtility.GetInstance(type);
                awards.Add(award);
            }

            return Request.CreateResponse(HttpStatusCode.OK, awards);
        }
    }
}