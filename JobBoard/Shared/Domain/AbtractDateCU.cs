using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Shared.Domain
{
    public abstract class AbtractDateCU
    {
        public DateTime DateCreatead { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
