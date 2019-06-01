using CandidateApplication.App_Data;
using CandidateApplication.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandidateApplication.Data
{
    public class CandidateLogic
    {
        private CandidateContext Context;
        public CandidateLogic()
        {
            Context = new CandidateContext();
        }

        public CandidateSearchModel GetCandidates (CandidateSearchModel model)
        {
            //replace * with % for text box wild card search
            if (model.SchFirst != null)
                model.SchFirst = model.SchFirst.Replace('*','%');
            if (model.SchLast != null)
                model.SchLast = model.SchLast.Replace('*', '%');
            if (model.SchPhone != null)
                model.SchPhone = model.SchPhone.Replace('*', '%');
            if (model.SchEmail != null)
                model.SchEmail = model.SchEmail.Replace('*', '%');
            if (model.SchZipCode != null)
                model.SchZipCode = model.SchZipCode.Replace('*', '%');
            
            //prepare qualification type parameter for stored procedure, matching multiple type
            if ((model.SchQTypes != null) && (model.SchQTypes.Any()))
            {
                string qtype = "";
                foreach (var item in model.SchQTypes)
                {
                    qtype += item + "|";
                }
                model.SchQuaType = qtype;
            }

            //prepare qualification name parameter for stored procedure, matching multiple name
            if ((model.SchQNames != null) && (model.SchQNames.Any()))
            {
                string qname = "";
                foreach (var item in model.SchQNames)
                {
                    qname += item + "|";
                }
                model.SchQuaName = qname;
            }

            //sql to linq execute the select candidate stored procedure
            CandidateDataClassesDataContext candidateData = new CandidateDataClassesDataContext();
            var result = candidateData.procCandidateSelect(model.SchFirst, model.SchLast, model.SchEmail, model.SchPhone,
                                 model.SchZipCode, model.SchQuaType, model.SchQuaName, model.SchDate);
            
            //get result and store in temporary candidate list
            List<Models.Candidate.Candidate> lstCandidate = new List<Models.Candidate.Candidate>();
            foreach (var item in result)
            {
                Models.Candidate.Candidate candidate = new Models.Candidate.Candidate();
                candidate.CandidateId = item.CandidateId;
                candidate.FirstName = item.FirstName;
                candidate.LastName = item.LastName;
                candidate.Email = item.Email;
                candidate.PhoneNumber = item.PhoneNumber;
                candidate.ZipCode = item.ZipCode;
                lstCandidate.Add(candidate);
            }

            //assign back to model candidate, get count and return model
            model.Candidates = lstCandidate;
            model.TotalRecords = model.Candidates.Count();
            return model;
        }
    }
}