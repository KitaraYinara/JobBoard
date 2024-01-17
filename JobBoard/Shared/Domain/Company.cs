using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Company : BaseDomainModel
    {
        public string? C_Name { get; set; }
        public string? C_Address { get; set; }
        public string? C_About { get; set; }
        public int AdminId { get; set; }
        public virtual Admin? Admin { get; set; }
    }
}
