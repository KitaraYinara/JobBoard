using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Admin : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name is not valid")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name conatins numbers")]
        public string? Ad_Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a vaild email")]
        [EmailAddress]
        public string? Ad_Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password is too short or too long")]
        public string? Ad_Password { get; set; }
        [Required]
        public int Ad_Age { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string? Ad_Mobile { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Ad_DateOfBirth { get; set; }
    }
}
