using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string? C_Name { get; set; }
        public string? C_Address { get; set; }
        public string? C_About { get; set; }
        public int AdminID { get; set; }
        public virtual Admin? Admin { get; set; }
        public string? IndustryID { get; set; }
        public virtual Industry? Industry { get; set; }
    }
}
