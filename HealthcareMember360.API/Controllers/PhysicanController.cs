using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareMember360.API.Controllers
{
    [Route("api/physican")]
    [ApiController]
    public class PhysicanController : ControllerBase
    {
        private readonly IPhysicanService _physicanService;

        public PhysicanController(IPhysicanService physicanService)
        {
            _physicanService = physicanService;
        }
        [HttpGet]
        public async Task<List<Physican>> GetPhysicans() => await _physicanService.GetPhysicans();
        [HttpGet("{physicianId}")]
        public async Task<Physican> GetPhysicanByID(int physicianId) => await _physicanService.GetPhysicanByID(physicianId);
        [HttpPost]
        public async Task<int> SavePhysican(Physican physican) => await _physicanService.SavePhysican(physican);
        [HttpPut]
        public async Task<int> UpdatePhysican(Physican physican) => await _physicanService.UpdatePhysican(physican);
        [HttpDelete]
        public async Task DeletePhysicanByID(int physicianId) => await _physicanService.DeletePhysicanByID(physicianId);
    }
}
