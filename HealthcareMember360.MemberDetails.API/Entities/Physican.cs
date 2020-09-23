using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareMember360.MemberDetails
{
    public class Physican
    {
        [Key]
        public int PhysicianId { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianState { get; set; }
    }
}
