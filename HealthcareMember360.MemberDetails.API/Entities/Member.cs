using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareMember360.MemberDetails
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string EmailAddress { get; set; }
        public string SSN { get; set; }
        public int PhysicianId { get; set; }
    }
}
