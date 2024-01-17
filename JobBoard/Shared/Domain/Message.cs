using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Message : BaseDomainModel
    {
        public string? M_Sender { get; set; }
        public string? M_Recipient { get; set; }
        public string? M_Content { get; set; }
        public DateTime M_TimeStamp { get; set; }
        public int EmployerId { get; set; }
        public virtual Employer? Employer { get; set; }
        public int ApplicantId { get; set; }
        public virtual Applicant? Applicant { get; set; }
    }
}
