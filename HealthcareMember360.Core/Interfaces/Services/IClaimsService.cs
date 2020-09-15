using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public interface IClaimsService
    {
        Task<List<ClaimDetails>> GetClaims();
        Task<ClaimDetails> GetClaimsByID(int claimID);
        Task<BaseResponse> SaveClaims(ClaimsRequest claimsRequest);
        Task<BaseResponse> UpdateClaims(ClaimDetails claimDetail);
        Task<BaseResponse> DeleteClaimsByID(int claimID);
        Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID);
    }
}
