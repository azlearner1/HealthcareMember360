using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthcareMember360.UpdateMember.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateMemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public UpdateMemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpPut]
        public async Task<BaseResponse> UpdateMember(Member member) => await _memberService.UpdateMember(member);
    }
}
