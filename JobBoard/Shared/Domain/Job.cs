using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JobBoard.Shared.Domain
{
    public class Job : BaseDomainModel, IValidatableObject
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name conatins numbers")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name is not valid")]
        public string? J_Name { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Name is not valid")]
        public string? J_Location { get; set; }
        [Required]
        public string? J_Description { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Salary is not a valid")]
        public int J_Salary { get; set; }
        [Required]
        public string? J_Type { get; set; }
        [Required]
        public string? J_Skills { get; set; }
        [Required]
        public bool J_Urgency { get; set; }
        [Required]
        public int? EmployerId { get; set; }
        public virtual Employer? Employer { get; set; }
        [Required]
        public int? IndustryId { get; set; }
        public virtual Industry? Industry { get; set; }
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
