using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Applicant : BaseDomainModel
    {
        public string? A_Name { get; set; }
        public string? A_Email { get; set; }
        public string? A_Password { get; set; }
        public int A_Age { get; set; }
        public string? A_Mobile { get; set; }
        public DateTime A_DateOfBirth { get; set; }
        public string? A_ReferralLink { get; set; }
    }
}
