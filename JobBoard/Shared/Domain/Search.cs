using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Search : AbtractDateCU
    {
        public int SearchID { get; set; }
        public string? Src_Job_Name { get; set; }
        public string? Src_Job_Type { get; set; }
        public string? Src_Location { get; set; }
        public int JobID { get; set; }
        public virtual Job? Job { get; set; }
        public int ApplicantID { get; set; }
        public virtual Applicant? Applicant { get; set; }
    }
}
