using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Employer : BaseDomainModel
    {
        public string? E_Name { get; set; }
        public string? E_Email { get; set; }
        public string? E_Password { get; set; }
        public int E_Age { get; set; }
        public string? E_Mobile { get; set; }
        public DateTime E_DateOfBirth { get; set; }
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual List<Job>? Jobs { get; set; }
    }
}
