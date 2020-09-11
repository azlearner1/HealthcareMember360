using System;

namespace HealthcareMember360.Core
{
    public class ClaimDetails
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Remarks { get; set; }
        public string MemberName { get; set; }
    }
}
