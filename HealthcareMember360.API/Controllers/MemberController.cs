using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.API.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public async Task<List<Member>> GetMembers() => await _memberService.GetMembers();
        [HttpGet("{memberID}")]
        public async Task<Member> GetMemberByID(int memberID) => await _memberService.GetMemberByID(memberID);
        [HttpPost]
        public async Task<int> SaveMember(MemberRequest memberRequest) => await _memberService.SaveMember(memberRequest);
        [HttpPut]
        public async Task<int> UpdateMember(Member member) => await _memberService.UpdateMember(member);
        [HttpDelete]
        public async Task DeleteMemberByID(int memberID) => await _memberService.DeleteMemberByID(memberID);
        [HttpGet]
        [Route("[action]/{memberID}")]
        public async Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID) => await _memberService.GetMemberPhysicianByMemberID(memberID);
    }
}
