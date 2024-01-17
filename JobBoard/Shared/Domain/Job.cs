using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Job : BaseDomainModel
    {
        public string? J_Name { get; set; }
        public string? J_Location { get; set; }
        public string? J_Description { get; set; }
        public int J_Salary { get; set; }
        public string? J_Type { get; set; }
        public string? J_Skills { get; set; }
        public bool J_Urgency { get; set; }
        public int EmployerId { get; set; }
        public virtual Employer? Employer { get; set; }
        public int IndustryId { get; set; }
        public virtual Industry? Industry { get; set; }
        public DateTime DateCreatead { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
