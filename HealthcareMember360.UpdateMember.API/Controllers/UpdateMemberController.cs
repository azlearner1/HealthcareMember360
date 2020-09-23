using HealthcareMember360.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMember360.UpdateMember.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateMemberController : ControllerBase
    {
        private readonly ILogger<UpdateMemberController> logger;
        private readonly IMemberService _memberService;
        private readonly IConfiguration _configuration;
        static ITopicClient topicClient;

        public UpdateMemberController(ILogger<UpdateMemberController> logger, IMemberService memberService, IConfiguration configuration)
        {
            logger = logger;
            _memberService = memberService;
            _configuration = configuration;
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMember(Member member)
        {
            try
            {
                if (member == null)
                    return BadRequest();

                string ServiceBusConnectionString = _configuration.GetSection("ConnectionStrings").GetSection("SendServiceBusConnection").Value;
                string TopicName = _configuration.GetSection("ConnectionStrings").GetSection("TopicName").Value;

                topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

                var serializeBody = JsonConvert.SerializeObject(member);

                var busMessage = new Message(Encoding.UTF8.GetBytes(serializeBody));

                await topicClient.SendAsync(busMessage);

                await topicClient.CloseAsync();

                return Created(HttpContext.Request.Scheme + HttpContext.Request.Host.ToUriComponent(), "Success");
                //return await _memberService.UpdateMember(member);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating Member record");
            }
            
        }
    }
}
