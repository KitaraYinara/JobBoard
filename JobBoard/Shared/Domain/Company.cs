using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Company : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Company Name is not valid")]
        public string? C_Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Company Address is not valid")]
        public string? C_Address { get; set; }
        [Required]
        public string? C_About { get; set; }
        [Required]
        public int? AdminId { get; set; }
        public virtual Admin? Admin { get; set; }
    }
}
