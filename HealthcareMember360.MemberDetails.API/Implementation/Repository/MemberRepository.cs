using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareMember360.MemberDetails
{
    public class MemberRepository : IMemberRepository
    {
        private readonly HM360DBContext _dBContext;
        public MemberRepository(HM360DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<Member> GetMemberByID(int memberID)
        {
            try
            {
                return await _dBContext.Member.AsNoTracking().Where(m => m.MemberID == memberID).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                //Log.Error("Exception occurred on Get Member By ID", ex);
                throw ex;
            }
        }
    }
}
