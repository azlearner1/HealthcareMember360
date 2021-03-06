﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public class PhysicanService : IPhysicanService
    {
        private readonly IPhysicanRepository _physicanRepository;
        public PhysicanService(IPhysicanRepository physicanRepository)
        {
            _physicanRepository = physicanRepository;
        }
        public async Task<List<Physican>> GetPhysicans()
        {
            return await _physicanRepository.GetPhysicans();
        }

        public async Task<Physican> GetPhysicanByID(int PhysicianId)
        {
            return await _physicanRepository.GetPhysicanByID(PhysicianId);
        }

        public async Task<BaseResponse> SavePhysican(Physican physican)
        {
            return await _physicanRepository.SavePhysican(physican);
        }

        public async Task<BaseResponse> UpdatePhysican(Physican physican)
        {
            return await _physicanRepository.UpdatePhysican(physican);
        }
        public async Task<BaseResponse> DeletePhysicanByID(int PhysicianId)
        {
            return await _physicanRepository.DeletePhysicanByID(PhysicianId);
        }
    }
}
