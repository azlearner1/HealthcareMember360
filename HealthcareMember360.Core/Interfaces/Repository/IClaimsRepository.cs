using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public interface IClaimsRepository
    {
        Task<List<ClaimDetails>> GetClaims();
        Task<ClaimDetails> GetClaimsByID(int claimID);
        Task<int> SaveClaims(ClaimsRequest claimsRequest);
        Task<int> UpdateClaims(ClaimDetails claimDetail);
        Task DeleteClaimsByID(int claimID);
        Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID);
    }
}
