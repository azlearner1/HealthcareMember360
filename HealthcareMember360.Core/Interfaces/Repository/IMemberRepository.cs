using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetMembers();
        Task<Member> GetMemberByID(int memberID);
        Task<BaseResponse> SaveMember(MemberRequest memberRequest);
        Task<BaseResponse> UpdateMember(Member member);
        Task<BaseResponse> DeleteMemberByID(int memberID);
        Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID);
    }
}
