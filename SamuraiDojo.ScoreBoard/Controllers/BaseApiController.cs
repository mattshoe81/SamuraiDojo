using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class BaseApiController : ApiController
    {
        protected MediaTypeFormatter Formatter;

        public BaseApiController()
        {
            Init();
        }

        private void Init()
        {
            //Formatter = Configuration.Formatters.JsonFormatter;
        }
    }
}