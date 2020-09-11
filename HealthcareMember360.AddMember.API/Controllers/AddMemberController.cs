using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthcareMember360.AddMember.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddMemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public AddMemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpPost]
        public async Task<int> AddMember(MemberRequest memberRequest) => await _memberService.SaveMember(memberRequest);
    }
}
