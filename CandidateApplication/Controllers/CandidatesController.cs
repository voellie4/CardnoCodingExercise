using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CandidateApplication.Data;
using CandidateApplication.Models.Candidate;

namespace CandidateApplication.Controllers
{
    public class CandidatesController : Controller
    {
        private CandidateContext db = new CandidateContext();

        //prepare select list for qualification type
        private MultiSelectList GetTypes(string[] selectedValues)
        {
            var qType = db.Qualifications.GroupBy(q=>q.QualificationType)
                .Select(grp=>grp.FirstOrDefault())
                .ToList();

            return new MultiSelectList(qType, "QualificationType", "QualificationType", selectedValues);
        }

        //prepare select list for qualification name
        private MultiSelectList GetNames(string[] selectedValues)
        {
            var qName = db.Qualifications.GroupBy(q => q.QualificationName)
                .Select(grp => grp.FirstOrDefault())
                .ToList();

            return new MultiSelectList(qName, "QualificationName", "QualificationName", selectedValues);
        }

        // GET: Candidates
        public ActionResult Index(CandidateSearchModel model)
        {
            //qualification type select list
            ViewBag.TypesList = GetTypes(null);

            //qualification name select list
            ViewBag.NamesList = GetNames(null);

            //doing search
            CandidateLogic candidateLogic = new CandidateLogic();
            model = candidateLogic.GetCandidates(model);

            return View(model);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            TempData["Message"] = "";
            return View();
        }

        // POST: Candidates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateId,FirstName,LastName,PhoneNumber,Email,ZipCode")] Candidate candidate)
        {
            //save candidate information then proceed to add qualification page
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidate);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    TempData["Message"] = "Duplicate phone number or email!";
                    return View(candidate);
                }
                return RedirectToAction("Create","Qualifications",new { id = candidate.CandidateId});
            }

            return View(candidate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
