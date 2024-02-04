using JobBoard.Shared.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Message : BaseDomainModel
    {
        [Required]
        public string? M_Sender { get; set; }
        [Required]
        public string? M_Recipient { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "M_Content cannot exceed 1000 characters.")]
        [DisallowCertainWords]
        public string? M_Content { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime M_TimeStamp { get; set; }
        public int EmployerId { get; set; }
        public virtual Employer? Employer { get; set; }
        public int ApplicantId { get; set; }
        public virtual Applicant? Applicant { get; set; }
    }
}
