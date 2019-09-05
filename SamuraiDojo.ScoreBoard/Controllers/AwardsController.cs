using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SamuraiDojo.Attributes.Bonus;
using SamuraiDojo.Interfaces;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Utility;
using SamuraiDojo.Utility.Interfaces;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class AwardsController : BaseApiController
    {
        private IReflectionUtility reflectionUtility;

        public AwardsController()
        {
            this.reflectionUtility = Factory.Get<IReflectionUtility>();
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Type[] awardTypes = reflectionUtility.GetSubTypes<BonusPointsAttribute>("SamuraiDojo");
            List<IBonusPointsAttribute> awards = new List<IBonusPointsAttribute>();

            foreach (Type type in awardTypes)
            {
                IBonusPointsAttribute award = (BonusPointsAttribute)reflectionUtility.GetInstance(type);
                awards.Add(award);
            }

            return Request.CreateResponse(HttpStatusCode.OK, awards);
        }
    }
}