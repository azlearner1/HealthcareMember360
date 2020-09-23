using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareMember360.MemberDetails
{
    public interface IMemberService
    {
        Task<Member> GetMemberByID(int memberID);
    }
}
