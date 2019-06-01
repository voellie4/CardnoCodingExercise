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
    public class QualificationsController : Controller
    {
        private CandidateContext db = new CandidateContext();

        // GET: Qualifications based on candidate id
        public ActionResult Index(int? id)
        {
            var qualifications = db.Qualifications.Include(q => q.Candidate).Where(q=>q.CandidateId==(int)id);
            return View(qualifications.ToList());
        }

        // GET: Qualifications/Create
        public ActionResult Create(int? id)
        {
            Qualification qualification = new Qualification();
            qualification.CandidateId = id.GetValueOrDefault();
            return View(qualification);
        }

        // POST: Qualifications/Create - submit application, save: no additional qualification - add more: add new qualification 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QualificationId,QualificationType,QualificationName,DateStarted,DateCompleted,CandidateId")] Qualification qualification
            , string save, string addMore)
        {
            if (ModelState.IsValid)
            {
                // if no qualification is entered, redirect to search page
                if ((qualification.QualificationType == null)
                    && (qualification.QualificationName == "" || qualification.QualificationType == null))
                {
                    return RedirectToAction("Index","Candidates");
                }

                //else save qualification
                db.Qualifications.Add(qualification);
                db.SaveChanges();

                //choose to save and complete creating candidate
                if (!string.IsNullOrEmpty(save))
                {
                    return RedirectToAction("Index", "Candidates");
                }
                //choose to add more qualification to the same candidate
                if (!string.IsNullOrEmpty(addMore))
                {
                    TempData["Message"] = "Qualification Saved";
                    return RedirectToAction("Create", "Qualifications", new { id = qualification.CandidateId});
                }
            }
            
            //fail to save, refresh page with the same candidate
            ViewBag.CandidateId = qualification.CandidateId;
            return View(qualification);
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
