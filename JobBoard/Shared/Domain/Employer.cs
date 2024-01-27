using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Employer : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name is not valid")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name conatins numbers")]
        public string? E_Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a vaild email")]
        [EmailAddress]
        public string? E_Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password is too short or too long")]
        public string? E_Password { get; set; }
        [Required]
        public int E_Age { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string? E_Mobile { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime E_DateOfBirth { get; set; }
        [Required]
        public int? CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual List<Job>? Jobs { get; set; }
    }
}
