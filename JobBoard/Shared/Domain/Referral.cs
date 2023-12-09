using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Referral
    {
        public int R_ID { get; set; }
        public string? R_Link { get; set; }
        public int JobID { get; set; }
        public virtual Job? Job { get; set; }
        public int ApplicantID { get; set; }
        public virtual Applicant? Applicant { get; set; }
        public int MessageID { get; set; }
        public virtual Message? Message { get; set; }
    }
}
