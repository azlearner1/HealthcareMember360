using System.ComponentModel.DataAnnotations;

namespace HealthcareMember360.Core
{
    public class Physican
    {
        [Key]
        public int PhysicianId { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianState { get; set; }
    }
}
