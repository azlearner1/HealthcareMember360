using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task<List<Member>> GetMembers()
        {
            return await _memberRepository.GetMembers();
        }

        public async Task<Member> GetMemberByID(int memberID)
        {
            return await _memberRepository.GetMemberByID(memberID);
        }

        public async Task<BaseResponse> SaveMember(MemberRequest memberRequest)
        {
            return await _memberRepository.SaveMember(memberRequest);
        }

        public async Task<BaseResponse> UpdateMember(Member member)
        {
            return await _memberRepository.UpdateMember(member);
        }
        public async Task<BaseResponse> DeleteMemberByID(int memberID)
        {
            return await _memberRepository.DeleteMemberByID(memberID);
        }

        public Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID)
        {
            return _memberRepository.GetMemberPhysicianByMemberID(memberID);
        }
    }
}
