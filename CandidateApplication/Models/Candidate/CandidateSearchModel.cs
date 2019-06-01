using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandidateApplication.Models.Candidate
{
    public class CandidateSearchModel
    {
        public string SchFirst { get; set; }
        public string SchLast { get; set; }
        public string SchPhone { get; set; }
        public string SchEmail { get; set; }
        public string SchZipCode { get; set; }
        public string SchQuaType { get; set; }
        public string SchQuaName { get; set; }
        public Int32 TotalRecords { get; set; }
        public DateTime? SchDate { get; set; }
        public List<string> SchQTypes { get; set; }
        public List<string> SchQNames { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}