using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthcareMember360.SubmitClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitClaimController : ControllerBase
    {
        private readonly IClaimsService _claimsService;
        public SubmitClaimController(IClaimsService claimsService)
        {
            _claimsService = claimsService;
        }
        [HttpPost]
        public async Task<BaseResponse> SubmitClaim(ClaimsRequest claimsRequest) => await _claimsService.SaveClaims(claimsRequest);
    }
}
