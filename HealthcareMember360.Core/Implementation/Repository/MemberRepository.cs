using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public class MemberRepository : IMemberRepository
    {
        private readonly HM360DBContext _dBContext;
        public MemberRepository(HM360DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<List<Member>> GetMembers()
        {
            try
            {
                return await _dBContext.Member.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Get Members", ex);
                throw ex;
            }
        }

        public async Task<Member> GetMemberByID(int memberID)
        {
            try
            {
                return await _dBContext.Member.AsNoTracking().Where(m => m.MemberID == memberID).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Get Member By ID", ex);
                throw ex;
            }
        }

        public async Task<BaseResponse> SaveMember(MemberRequest memberRequest)
        {
            try
            {
                Member member = new Member();
                if (memberRequest != null)
                {
                    var minresult = await _dBContext.Physican.AsNoTracking().MinAsync(x => x.PhysicianId);
                    var maxresult = await _dBContext.Physican.AsNoTracking().MaxAsync(x => x.PhysicianId);

                    Random random = new Random();
                    int randomPhysicianId = random.Next(minresult, maxresult);
                    //member.PhysicianId = randomPhysicianId;

                    member = new Member()
                    {
                        MemberID = 0,
                        FirstName = memberRequest.FirstName,
                        LastName = memberRequest.LastName,
                        EmailAddress = memberRequest.EmailAddress,
                        Address = memberRequest.Address,
                        SSN = memberRequest.SSN,
                        State = memberRequest.State,
                        PhysicianId = randomPhysicianId
                    };

                    _dBContext.Member.Add(member);
                    await _dBContext.SaveChangesAsync();
                }
                return new BaseResponse()
                {
                    StatusCode = StatusCodes.Status201Created,
                    StatusDescription = " Member Details Added Successfully! ",
                    ID = member.MemberID
                };
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Save Member", ex);
                return new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError, StatusDescription = "Internal Server Error" };
            }
        }

        public async Task<BaseResponse> UpdateMember(Member member)
        {
            try
            {
                var resmember = await _dBContext.Member.AsNoTracking().Where(m => m.MemberID == member.MemberID).FirstOrDefaultAsync();
                if (resmember == null)
                {
                    var minresult = await _dBContext.Physican.AsNoTracking().MinAsync(x => x.PhysicianId);
                    var maxresult = await _dBContext.Physican.AsNoTracking().MaxAsync(x => x.PhysicianId);

                    Random random = new Random();
                    int randomPhysicianId = random.Next(minresult, maxresult);
                    member.PhysicianId = randomPhysicianId;

                    _dBContext.Member.Add(member);
                    await _dBContext.SaveChangesAsync();
                    return new BaseResponse()
                    {
                        StatusCode = StatusCodes.Status201Created,
                        StatusDescription = " Member Details Added Successfully! ",
                        ID = member.MemberID
                    };
                }
                else
                {
                    _dBContext.Member.UpdateRange(member);
                    await _dBContext.SaveChangesAsync();
                    return new BaseResponse()
                    {
                        StatusCode = StatusCodes.Status202Accepted,
                        StatusDescription = " Member Details Updated Successfully! ",
                        ID = member.MemberID
                    };
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Update Member", ex);
                return new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError, StatusDescription = "Internal Server Error" };
            }
        }
        public async Task<BaseResponse> DeleteMemberByID(int memberID)
        {
            try
            {
                var member = await _dBContext.Member.AsNoTracking().Where(m => m.MemberID == memberID).FirstOrDefaultAsync<Member>();
                if (member != null)
                {
                    _dBContext.Member.Remove(member);
                    await _dBContext.SaveChangesAsync();
                }
                return new BaseResponse()
                {
                    StatusCode = StatusCodes.Status200OK,
                    StatusDescription = " Member Deleted Successfully! ",
                    ID = memberID
                };
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Delete Member By ID", ex);
                return new BaseResponse { StatusCode = StatusCodes.Status500InternalServerError, StatusDescription = "Internal Server Error" };
            }
        }

        public async Task<MemberPhysician> GetMemberPhysicianByMemberID(int memberID)
        {
            try
            {
                MemberPhysician memberPhysician = await (from member in _dBContext.Member.AsNoTracking()
                                                         join physician in _dBContext.Physican on member.PhysicianId equals physician.PhysicianId
                                                         where member.MemberID == memberID
                                                         select new MemberPhysician
                                                         {
                                                             MemberId = member.MemberID,
                                                             FirstName = member.FirstName,
                                                             LastName = member.LastName,
                                                             PhysicianName = physician.PhysicianName
                                                         }).FirstOrDefaultAsync();
                return memberPhysician;
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Get Member Physician By Member ID", ex);
                throw ex;
            }
        }
    }
}
