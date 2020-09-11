using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public interface IMemberService
    {
        Task<List<Member>> GetMembers();
        Task<Member> GetMemberByID(int memberID);
        Task<int> SaveMember(MemberRequest memberRequest);
        Task<int> UpdateMember(Member member);
        Task DeleteMemberByID(int memberID);
        Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID);
    }
}
