using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SamuraiDojo.Utility.Interfaces;

namespace SamuraiDojo.Services.Implementations
{
    internal abstract class ServiceBase
    {
        protected ILog log;

        public ServiceBase(ILog log)
        {
            this.log = log;
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
                log.Exception(ex, "Unable to get user name");
                username = string.Empty;
            }

            return username;
        }
    }
}
