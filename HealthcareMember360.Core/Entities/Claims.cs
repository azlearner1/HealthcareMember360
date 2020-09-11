using System;
using System.ComponentModel.DataAnnotations;

namespace HealthcareMember360.Core
{
    public class Claims
    {
        [Key]
        public int ClaimID { get; set; }
        public int ClaimType { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Remarks { get; set; }
        public int MemberID { get; set; }
    }
}
