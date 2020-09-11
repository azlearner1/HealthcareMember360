using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.Core
{
    public interface IPhysicanRepository
    {
        Task<List<Physican>> GetPhysicans();
        Task<Physican> GetPhysicanByID(int physicianId);
        Task<int> SavePhysican(Physican physican);
        Task<int> UpdatePhysican(Physican physican);
        Task DeletePhysicanByID(int physicianId);
    }
}
