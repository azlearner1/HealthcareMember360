using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.API.Controllers
{
    [Route("api/claims")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsService _claimsService;
        public ClaimsController(IClaimsService claimsService)
        {
            _claimsService = claimsService;
        }
        [HttpGet]
        public async Task<List<ClaimDetails>> GetClaims() => await _claimsService.GetClaims();
        [HttpGet("{claimID}")]
        public async Task<ClaimDetails> GetClaimsByID(int claimID) => await _claimsService.GetClaimsByID(claimID);
        [HttpGet]
        [Route("[action]/{memberID}")]
        public async Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID) => await _claimsService.GetClaimsDetailsByMemberID(memberID);
        [HttpPost]
        public async Task<int> SaveClaims(ClaimsRequest claimsRequest) => await _claimsService.SaveClaims(claimsRequest);
        [HttpPut]
        public async Task<int> UpdateClaims(ClaimDetails claimDetails) => await _claimsService.UpdateClaims(claimDetails);
        [HttpDelete]
        public async Task DeleteClaimsByID(int claimID) => await _claimsService.DeleteClaimsByID(claimID);

    }
}
