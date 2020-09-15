using HealthcareMember360.Core;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<List<Member>>> GetMembers()
        {
            try
            {
                var result = await _memberService.GetMembers();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }
        [HttpGet("{memberID}")]
        public async Task<ActionResult<Member>> GetMemberByID(int memberID)
        {
            var result = await _memberService.GetMemberByID(memberID);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> SaveMember(MemberRequest memberRequest)
        {
            try
            {
                var result = await _memberService.SaveMember(memberRequest);
                return CreatedAtAction(nameof(SaveMember), new { id = result.ID }, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdateMember(Member member)
        {
            var result = await _memberService.UpdateMember(member);
            return StatusCode(StatusCodes.Status202Accepted, result.ID);
        }
        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DeleteMemberByID(int memberID)
        {
            var result = await _memberService.DeleteMemberByID(memberID);
            return Ok(result);
        }
        [HttpGet]
        [Route("[action]/{memberID}")]
        public async Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID) => await _memberService.GetMemberPhysicianByMemberID(memberID);
    }
}
