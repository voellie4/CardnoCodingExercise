using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CandidateApplication.Models.Candidate
{
    public class Qualification
    {
        public int QualificationId { get; set; }

        [Display(Name = "Qualification Type")]
        [StringLength(30)]
        public string QualificationType { get; set; }

        [Display(Name = "Qualification Name")]
        public string QualificationName { get; set; }

        [Display(Name = "Date Started")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? DateStarted { get; set; }

        [Display(Name = "Date Completed")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")] 
        public DateTime? DateCompleted { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}