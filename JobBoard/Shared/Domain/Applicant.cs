using JobBoard.Shared.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Applicant : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name is not valid")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains numbers")]
        public string? A_Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a vaild email")]
        [EmailAddress]
        public string? A_Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password is too short or too long")]
        public string? A_Password { get; set; }
        [Required]
        public int A_Age { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string? A_Mobile { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime A_DateOfBirth { get; set; }
        [Required]
        [UrlOrSpecificValue("NA", ErrorMessage = "The {0} field must be a valid URL or 'NA'.")]
        public string? A_ReferralLink { get; set; }
    }
}
