using System.ComponentModel.DataAnnotations;

namespace HealthcareMember360.Core
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
