using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public interface IPhysicanRepository
    {
        Task<List<Physican>> GetPhysicans();
        Task<Physican> GetPhysicanByID(int physicianId);
        Task<BaseResponse> SavePhysican(Physican physican);
        Task<BaseResponse> UpdatePhysican(Physican physican);
        Task<BaseResponse> DeletePhysicanByID(int physicianId);
    }
}
