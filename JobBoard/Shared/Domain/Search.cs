using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Search : BaseDomainModel, IValidatableObject
    {
        [Required]
        public string? Src_Job_Name { get; set; }
        [Required]
        public string? Src_Job_Type { get; set; }
        [Required]
        public string? Src_Location { get; set; }
        [Required]
        public int? JobId { get; set; }
        public virtual Job? Job { get; set; }
        [Required]
        public int? ApplicantId { get; set; }
        public virtual Applicant? Applicant { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateUpdated { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();
            if (DateUpdated != null | DateCreated != null)
            {
                if (DateUpdated < DateCreated)
                {
                    yield return new ValidationResult("DateUpdated must be greater than DateCreated", new[] { "DateUpdated" });
                }
            }
        }
    }
}
