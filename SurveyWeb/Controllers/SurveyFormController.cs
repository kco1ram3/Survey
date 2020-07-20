using Survey;
using SurveyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyWeb.Controllers
{
    public class SurveyFormController : Controller
    {
        //
        // GET: /SurveyForm/
        public ActionResult Index()
        {
            NHibertnateSession context = new NHibertnateSession();

            SurveyForm form =  context.PersistenceSession
                                .QueryOver<SurveyForm>()
                                .Where(t => t.Title == "HOSPITAL SURVEY ON PATIENT SAFETY CULTURE")
                                .SingleOrDefault();
            return View(form);
        }
	}
}