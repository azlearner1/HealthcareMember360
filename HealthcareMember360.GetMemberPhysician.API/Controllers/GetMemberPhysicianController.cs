using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthcareMember360.GetMemberPhysician.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMemberPhysicianController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public GetMemberPhysicianController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public async Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID) => await _memberService.GetMemberPhysicianByMemberID(memberID);
    }
}
