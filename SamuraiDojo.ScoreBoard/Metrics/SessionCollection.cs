using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamuraiDojo.ScoreBoard.Metrics
{
    public class SessionCollection : IEnumerable<Session>
    {
        public int Count => Sessions.Count;

        private HashSet<Session> Sessions { get; set; }

        public SessionCollection()
        {
            Sessions = new HashSet<Session>();
        }

        public bool Contains(string sessionId)
        {
            bool contains = Sessions.Any(session => session.SessionID == sessionId);
            return contains;
        }

        public Session Get(string sessionId)
        {
            return Sessions.Where(session => session.SessionID == sessionId).FirstOrDefault();
        }

        public void Add(Session session)
        {
            if (!Contains(session.SessionID))
                Sessions.Add(session);
        }

        public IEnumerator<Session> GetEnumerator()
        {
            return Sessions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Sessions.GetEnumerator();
        }
    }
}