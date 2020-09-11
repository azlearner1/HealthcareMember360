using System.ComponentModel.DataAnnotations;

namespace HealthcareMember360.Core
{
    public class ClaimTypes
    {
        [Key]
        public int ClaimTypeID { get; set; }
        public string ClaimType { get; set; }
    }
}
