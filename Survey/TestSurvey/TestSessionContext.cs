using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Survey;

namespace TestSurvey
{
    [Serializable]
    public class TestSessionContext : Context
    {
        static TestSessionContext()
        {
            if (null == Context.SessionFactory)
            {
                try
                {
                    NHibernate.Cfg.Configuration hibernateConfig = new NHibernate.Cfg.Configuration().Configure();
                    hibernateConfig.AddAssembly("SurveyORM");
                    Context.SessionFactory = hibernateConfig.BuildSessionFactory();
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
    }
}
