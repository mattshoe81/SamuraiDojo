using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class BaseApiController : ApiController
    {
        protected MediaTypeFormatter Formatter;
        protected ILog Log;

        public BaseApiController() : base()
        {
            Init();
            Log = Factory.Get<ILog>();
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
            catch (Exception ex)
            {
                Log.Exception(ex, "Unable to get user name");
                username = string.Empty;
            }

            return username;
        }
    }
}