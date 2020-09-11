using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.GetClaims.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetClaimsController : ControllerBase
    {
        private readonly IClaimsService _claimsService;
        public GetClaimsController(IClaimsService claimsService)
        {
            _claimsService = claimsService;
        }
        [HttpGet]
        public async Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID) => await _claimsService.GetClaimsDetailsByMemberID(memberID);
    }
}
