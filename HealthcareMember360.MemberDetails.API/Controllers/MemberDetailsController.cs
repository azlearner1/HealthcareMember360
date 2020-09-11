using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthcareMember360.MemberDetails.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberDetailsController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberDetailsController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet("{memberID}")]
        public async Task<Member> GetMemberByID(int memberID) => await _memberService.GetMemberByID(memberID);
    }
}
