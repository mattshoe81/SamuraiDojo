using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamuraiDojo.ScoreBoard.Metrics
{
    public class MetricsRepo
    {
        public static SessionCollection Sessions { get; private set; }

        public static int VisitorCount => Sessions.Count;

        private static object sessionLock = new object();

        static MetricsRepo()
        {
            Sessions = new SessionCollection();
        }

        public static Session RegisterSession(HttpContextBase httpContext)
        {
            Session session;
            lock (sessionLock)
            {
                if (!Sessions.Contains(httpContext.Session.SessionID))
                {
                    session = new Session
                    {
                        IP = httpContext.Request.UserHostAddress,
                        SessionID = httpContext.Session.SessionID,
                        Browser = httpContext.Request.Browser.Browser,
                        Username = httpContext.User.Identity.Name
                    };
                    Sessions.Add(session);
                }
                else
                    session = Sessions.Get(httpContext.Session.SessionID);
            }

            return session;
        }

    }
}