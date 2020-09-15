using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public class ClaimsService : IClaimsService
    {
        private readonly IClaimsRepository _claimsRepository;

        public ClaimsService(IClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
        }
        public async Task<List<ClaimDetails>> GetClaims()
        {
            return await _claimsRepository.GetClaims();
        }

        public async Task<ClaimDetails> GetClaimsByID(int claimID)
        {
            return await _claimsRepository.GetClaimsByID(claimID);
        }

        public async Task<BaseResponse> SaveClaims(ClaimsRequest claimsRequest)
        {
            return await _claimsRepository.SaveClaims(claimsRequest);
        }

        public async Task<BaseResponse> UpdateClaims(ClaimDetails claimDetail)
        {
            return await _claimsRepository.UpdateClaims(claimDetail);
        }
        public async Task<BaseResponse> DeleteClaimsByID(int claimID)
        {
            return await _claimsRepository.DeleteClaimsByID(claimID);
        }
        public async Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID)
        {
            return await _claimsRepository.GetClaimsDetailsByMemberID(memberID);
        }
    }
}
