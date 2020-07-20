using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey;

namespace SurveyWeb.Models
{
    [Serializable]
    public class NHibertnateSession : Context
    {
        static NHibertnateSession()
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