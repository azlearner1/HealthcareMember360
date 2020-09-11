using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareMember360.Core
{
    public class ClaimsRequest
    {
        public string ClaimType { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Remarks { get; set; }
        public string MemberName { get; set; }
    }
}
