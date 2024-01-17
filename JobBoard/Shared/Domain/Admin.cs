using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public class Admin : BaseDomainModel
    {
        public string? Ad_Name { get; set; }
        public string? Ad_Email { get; set; }
        public string? Ad_Password { get; set; }
        public int Ad_Age { get; set; }
        public string? Ad_Mobile { get; set; }
        public DateTime Ad_DateOfBirth { get; set; }
    }
}
