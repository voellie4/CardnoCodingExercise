using CandidateApplication.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CandidateApplication.Data
{
    public class CandidateContext: DbContext
    {
        public CandidateContext() : base("DefaultConnection")
        { }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }


    }
}