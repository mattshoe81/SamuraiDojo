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

        public BaseApiController() : base()
        {
            Init();
        }

        private void Init()
        {

        }

        protected string GetCurrentUsername()
        {
            string username;
            try
            {
                string full = HttpContext.Current.User.Identity.Name;
                username = full.Substring(full.LastIndexOf('\\') + 1);
            }
            catch
            {
                username = string.Empty;
            }

            return username;
        }
    }
}