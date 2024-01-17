using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Search : BaseDomainModel
    {
        public string? Src_Job_Name { get; set; }
        public string? Src_Job_Type { get; set; }
        public string? Src_Location { get; set; }
        public int JobId { get; set; }
        public virtual Job? Job { get; set; }
        public int ApplicantId { get; set; }
        public virtual Applicant? Applicant { get; set; }
        public DateTime DateCreatead { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
