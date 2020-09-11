using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public class PhysicanRepository : IPhysicanRepository
    {
        private readonly HM360DBContext _dBContext;

        public PhysicanRepository(HM360DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<List<Physican>> GetPhysicans()
        {
            try
            {
                return await _dBContext.Physican.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Get Physicans", ex);
                throw ex;
            }
        }

        public async Task<Physican> GetPhysicanByID(int physicianId)
        {
            try
            {
                return await _dBContext.Physican.AsNoTracking().Where(p => p.PhysicianId == physicianId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Get Physican By ID", ex);
                throw ex;
            }
        }

        public async Task<int> SavePhysican(Physican physican)
        {
            try
            {
                var resphysican = await _dBContext.Physican.AsNoTracking().Where(p => p.PhysicianId == physican.PhysicianId).FirstOrDefaultAsync();
                if (resphysican == null)
                {
                    _dBContext.Physican.Add(physican);
                    await _dBContext.SaveChangesAsync();
                }
                else
                {
                    _dBContext.Physican.UpdateRange(physican);
                    await _dBContext.SaveChangesAsync();
                }
                return physican.PhysicianId;
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Save Physican By ID", ex);
                throw ex;
            }
        }

        public async Task<int> UpdatePhysican(Physican physican)
        {
            try
            {
                var resphysican = await _dBContext.Physican.AsNoTracking().Where(p => p.PhysicianId == physican.PhysicianId).FirstOrDefaultAsync();
                if (resphysican == null)
                {
                    _dBContext.Physican.Add(physican);
                    await _dBContext.SaveChangesAsync();
                }
                else
                {
                    _dBContext.Physican.UpdateRange(physican);
                    await _dBContext.SaveChangesAsync();
                }
                return physican.PhysicianId;
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Update Physican By ID", ex);
                throw ex;
            }
        }
        public async Task DeletePhysicanByID(int physicianId)
        {
            try
            {
                var physican = await _dBContext.Physican.AsNoTracking().Where(p => p.PhysicianId == physicianId).FirstOrDefaultAsync<Physican>();
                if (physican != null)
                {
                    _dBContext.Physican.Remove(physican);
                    await _dBContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception occurred on Delete Physican By ID", ex);
                throw ex;
            }
        }
    }
}
