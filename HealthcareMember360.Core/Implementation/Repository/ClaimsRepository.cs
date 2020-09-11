using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly HM360DBContext _dBContext;
        public ClaimsRepository(HM360DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<List<ClaimDetails>> GetClaims()
        {
            try
            {
                List<ClaimDetails> Claim = await (from claim in _dBContext.Claims.AsNoTracking()
                                                  join clainType in _dBContext.ClaimTypes.AsNoTracking() on claim.ClaimType equals clainType.ClaimTypeID
                                                  join member in _dBContext.Member.AsNoTracking() on claim.MemberID equals member.MemberID
                                                  select new ClaimDetails
                                                  {
                                                      ClaimID = claim.ClaimID,
                                                      ClaimAmount = claim.ClaimAmount,
                                                      ClaimDate = claim.ClaimDate,
                                                      ClaimType = clainType.ClaimType,
                                                      Remarks = claim.Remarks,
                                                      MemberName = member.FirstName + " " + member.LastName
                                                  }
                                            ).ToListAsync();
                return Claim;
                //return await _dBContext.Claims
                //            .Include(x=>x.ClaimType).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Get Claims", ex);
                throw ex;
            }
        }

        public async Task<ClaimDetails> GetClaimsByID(int claimID)
        {
            try
            {
                ClaimDetails claimDetail = await (from claim in _dBContext.Claims.AsNoTracking()
                                                  join clainType in _dBContext.ClaimTypes.AsNoTracking() on claim.ClaimType equals clainType.ClaimTypeID
                                                  join member in _dBContext.Member.AsNoTracking() on claim.MemberID equals member.MemberID
                                                  where claim.ClaimID == claimID
                                                  select new ClaimDetails
                                                  {
                                                      ClaimID = claim.ClaimID,
                                                      ClaimAmount = claim.ClaimAmount,
                                                      ClaimDate = claim.ClaimDate,
                                                      ClaimType = clainType.ClaimType,
                                                      Remarks = claim.Remarks,
                                                      MemberName = member.FirstName + " " + member.LastName
                                                  }
                                            ).FirstOrDefaultAsync();
                return claimDetail;
                //return await _dBContext.Claims.AsNoTracking().Where(c => c.ClaimID == claimID).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Get Claim By ID", ex);
                throw ex;
            }
        }

        public async Task<int> SaveClaims(ClaimsRequest claimsRequest)
        {
            try
            {
                Claims claims = new Claims();
                ClaimTypes claimType = await _dBContext.ClaimTypes.AsNoTracking().Where(c => c.ClaimType == claimsRequest.ClaimType).FirstOrDefaultAsync();
                Member member = await _dBContext.Member.AsNoTracking().Where(m => m.FirstName + " " + m.LastName == claimsRequest.MemberName).FirstOrDefaultAsync();

                //var claim = await _dBContext.Claims.AsNoTracking().Where(c => c.ClaimID == claimDetail.ClaimID).FirstOrDefaultAsync();
                if (claimsRequest != null)
                {
                    claims = new Claims()
                    {
                        ClaimID = 0,
                        ClaimType = claimType.ClaimTypeID,
                        ClaimAmount = claimsRequest.ClaimAmount,
                        ClaimDate = claimsRequest.ClaimDate,
                        Remarks = claimsRequest.Remarks,
                        MemberID = member.MemberID
                    };
                    _dBContext.Claims.Add(claims);
                    await _dBContext.SaveChangesAsync();
                }
                return claims.ClaimID;
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Save Claims", ex);
                throw ex;
            }
        }

        public async Task<int> UpdateClaims(ClaimDetails claimDetail)
        {
            try
            {
                ClaimTypes claimType = await _dBContext.ClaimTypes.AsNoTracking().Where(c => c.ClaimType == claimDetail.ClaimType).FirstOrDefaultAsync();
                Member member = await _dBContext.Member.AsNoTracking().Where(m => m.FirstName + " " + m.LastName == claimDetail.MemberName).FirstOrDefaultAsync();

                var claim = await _dBContext.Claims.AsNoTracking().Where(c => c.ClaimID == claimDetail.ClaimID).FirstOrDefaultAsync();
                if (claim == null)
                {
                    Claims claims = new Claims()
                    {
                        ClaimID = 0,
                        ClaimType = claimType.ClaimTypeID,
                        ClaimAmount = claimDetail.ClaimAmount,
                        ClaimDate = claimDetail.ClaimDate,
                        Remarks = claimDetail.Remarks,
                        MemberID = member.MemberID
                    };
                    _dBContext.Claims.Add(claims);
                    await _dBContext.SaveChangesAsync();
                }
                else
                {
                    claim = new Claims()
                    {
                        ClaimID = claimDetail.ClaimID,
                        ClaimType = claimType.ClaimTypeID,
                        ClaimAmount = claimDetail.ClaimAmount,
                        ClaimDate = claimDetail.ClaimDate,
                        Remarks = claimDetail.Remarks,
                        MemberID = member.MemberID
                    };
                    _dBContext.Claims.UpdateRange(claim);
                    await _dBContext.SaveChangesAsync();
                }
                return claimDetail.ClaimID;
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Update Claims", ex);
                throw ex;
            }
        }
        public async Task DeleteClaimsByID(int claimID)
        {
            try
            {
                var claim = await _dBContext.Claims.AsNoTracking().Where(c => c.ClaimID == claimID).FirstOrDefaultAsync<Claims>();
                if (claim != null)
                {
                    _dBContext.Claims.Remove(claim);
                    await _dBContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Delete Claim", ex);
                throw ex;
            }
        }

        public async Task<List<ClaimDetails>> GetClaimsDetailsByMemberID(int memberID)
        {
            try
            {
                List<ClaimDetails> claimDetails = await (from claim in _dBContext.Claims.AsNoTracking()
                                                         join clainType in _dBContext.ClaimTypes.AsNoTracking() on claim.ClaimType equals clainType.ClaimTypeID
                                                         join member in _dBContext.Member.AsNoTracking() on claim.MemberID equals member.MemberID
                                                         where member.MemberID == memberID
                                                         select new ClaimDetails
                                                         {
                                                             ClaimID = claim.ClaimID,
                                                             ClaimAmount = claim.ClaimAmount,
                                                             ClaimDate = claim.ClaimDate,
                                                             ClaimType = clainType.ClaimType,
                                                             Remarks = claim.Remarks,
                                                             MemberName = member.FirstName + " " + member.LastName
                                                         }
                                            ).ToListAsync();
                return claimDetails;
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Get Claims Details By MemberID", ex);
                throw ex;
            }
        }
    }
}
