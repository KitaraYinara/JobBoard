using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Industry : BaseDomainModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains numbers")]
        public string? I_Type { get; set; }
    }
}
