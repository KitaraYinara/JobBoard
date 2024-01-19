using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class JobApplication : BaseDomainModel
    {
        public string? JA_CoverLetter { get; set; }
        public string? JA_Resume { get; set; }
        public string? JA_Portfolio { get; set; }
        public string? JA_Status { get; set; }
        public int JobId { get; set; }
        public virtual Job? Job { get; set; }
        public int ApplicantId { get; set; }
        public virtual Applicant? Applicant { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
