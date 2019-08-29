using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamuraiDojo.ScoreBoard.Metrics
{
    public class SessionCollection : IEnumerable<Session>
    {
        public int Count => sessions.Count;

        private HashSet<Session> sessions { get; set; }
        private readonly object sessionLock = new object();

        public SessionCollection()
        {
            sessions = new HashSet<Session>();
        }

        public bool Contains(string sessionId)
        {
            bool contains = false;
            lock (sessionLock)
            {
                contains = sessions.Any(session => session.SessionID == sessionId);
            }

            return contains;
        }

        public Session Get(string sessionId)
        {
            Session session = null;
            lock (sessionLock)
            {
                session = sessions.Where(sess => sess.SessionID == sessionId).FirstOrDefault();
            }

            return session;
        }

        public void Add(Session session)
        {
            if (!Contains(session.SessionID))
            {
                lock (sessionLock)
                {
                    sessions.Add(session);
                }
            }
        }

        public IEnumerator<Session> GetEnumerator()
        {
            IEnumerator<Session> enumerator = null;
            lock (sessionLock)
            {
                enumerator = sessions.GetEnumerator();
            }

            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerator enumerator = null;
            lock (sessionLock)
            {
                enumerator = sessions.GetEnumerator();
            }

            return enumerator;
        }
    }
}