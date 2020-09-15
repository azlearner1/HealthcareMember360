using HealthcareMember360.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.GetClaims.Test
{
    public class GetClaimsService : IClaimsService
    {
        private List<ClaimDetails> _claimDetails;
        public GetClaimsService()
        {
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

        public Task<List<ClaimDetails>> GetClaims()
        {
            //return Task.FromResult<List<ClaimDetails>>();
            throw new NotImplementedException();
        }

        public Task<ClaimDetails> GetClaimsByID(int claimID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID)
        {
            return await Task.FromResult<List<ClaimDetails>>(_claimDetails);
        }

        public Task<int> SaveClaims(ClaimsRequest claimsRequest)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateClaims(ClaimDetails claimDetail)
        {
            throw new NotImplementedException();
        }
        public Task DeleteClaimsByID(int claimID)
        {
            throw new NotImplementedException();
        }
    }
}
