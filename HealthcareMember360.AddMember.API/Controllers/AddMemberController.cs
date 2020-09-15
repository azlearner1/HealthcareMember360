using HealthcareMember360.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMember360.AddMember.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddMemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IConfiguration _configuration;
        static ITopicClient topicClient;

        public AddMemberController(IMemberService memberService, IConfiguration configuration)
        {
            _memberService = memberService;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> AddMember(MemberRequest memberRequest)
        {
            try
            {
                if (memberRequest == null)
                    return BadRequest();

                string ServiceBusConnectionString = _configuration.GetSection("ConnectionStrings").GetSection("SendServiceBusConnection").Value;
                string TopicName = _configuration.GetSection("ConnectionStrings").GetSection("TopicName").Value;

                topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

                var serializeBody = JsonConvert.SerializeObject(memberRequest);

                var busMessage = new Message(Encoding.UTF8.GetBytes(serializeBody));

                await topicClient.SendAsync(busMessage);

                await topicClient.CloseAsync();

                var result = await _memberService.SaveMember(memberRequest);

                return CreatedAtAction(nameof(AddMember), new { id = result.ID }, result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }
    }
}
