using EnterpriseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseManager.Controllers
{
    public class CaseAnalysisController : Controller
    {
        ChoiceDB db = new ChoiceDB();
        CaseAnalysis andlysis = new CaseAnalysis();
        MultipleChoice choice = new MultipleChoice();
        public ActionResult Index()
        {
            var doc = new List<CaseAnalysis>();
            doc = db.CaseAnalysiss.OrderBy(d => d.Id).ToList();
            return View(doc);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseAnalysis andlysis = db.CaseAnalysiss.Find(id);
            db.Entry(andlysis).Collection(x => x.Topics).Load();//手动读取List

            if (id == null)
            {
                return HttpNotFound();
            }
            return View(andlysis);
        }
        public ActionResult ChoiceDetails(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleChoice choices = db.MultipleChoices.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(choices);
        }

        public ActionResult Testing()
        {
            return View();
        }

        public ActionResult VIP()
        {
            var doc = new List<MultipleChoice>();
            doc = db.MultipleChoices.OrderBy(d => d.Id).ToList();
            return View(doc);
        }
    }
}