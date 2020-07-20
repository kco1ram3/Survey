using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace Survey
{
    [Serializable]
    public class Context
    {
        public static ISessionFactory SessionFactory { get; set; }

        private ISession persistenceSession;
        public virtual ISession PersistenceSession
        {
            get
            {
                if (null == this.persistenceSession)
                {
                    this.persistenceSession = SessionFactory.OpenSession();
                    this.persistenceSession.FlushMode = FlushMode.Commit;
                }
                return this.persistenceSession;
            }
            internal set { this.persistenceSession = value; }
        }

        public virtual void Close()
        {
            if (null != this.persistenceSession)
            {
                this.persistenceSession.Flush();
                this.persistenceSession.Close();
                this.persistenceSession.Dispose();
                this.persistenceSession = null;
            }
        }

        public void Update(object obj)
        {
            this.PersistenceSession.Update(obj);
        }

        public virtual void Persist(object obj)
        {
            this.PersistenceSession.SaveOrUpdate(obj);
        }
    }
}