using HealthcareMember360.Core;
using HealthcareMember360.GetClaims.API.Controllers;
using HealthcareMember360.GetClaims.Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HealthcareMember360.GetClaims
{
    public class GetClaimsControllerTest
    {
        private readonly IClaimsService _claimsService;
        private GetClaimsController _claimsContoller;
        private List<ClaimDetails> _claimDetails;

        public GetClaimsControllerTest()
        {
            _claimsService = new GetClaimsService();
            _claimsContoller = new GetClaimsController(_claimsService);

            _claimDetails = new List<ClaimDetails>();
            _claimDetails.Add(new ClaimDetails()
            {
                ClaimID = 1,
                ClaimAmount = 1000,
                ClaimDate = DateTime.Now,
                ClaimType = "Vision",
                Remarks = "Test Remark",
                MemberName = "Senthilkumar Arjunan"
            });
        }
        [Test]
        public void GetClaimsDetailsByMemberID(int memberID)
        {
            var result = _claimsContoller.GetClaimsDetailsByMemberID(1);
        }
    }
}
