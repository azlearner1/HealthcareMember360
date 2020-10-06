using HealthcareMember360.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace HealthcareMember360.SubmitClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitClaimController : ControllerBase
    {
        private readonly IClaimsService _claimsService;
        private readonly IConfiguration _configuration;
        static ITopicClient topicClient;

        public SubmitClaimController(IClaimsService claimsService, IConfiguration configuration)
        {
            _claimsService = claimsService;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult> SubmitClaim(ClaimsRequest claimsRequest)
        {
            try
            {
                if (claimsRequest == null)
                    return BadRequest();

                string ServiceBusConnectionString = _configuration.GetSection("ConnectionStrings").GetSection("SendServiceBusConnection").Value;
                string TopicName = _configuration.GetSection("ConnectionStrings").GetSection("TopicName").Value;

                topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

                var serializeBody = JsonConvert.SerializeObject(claimsRequest);

                var busMessage = new Message(Encoding.UTF8.GetBytes(serializeBody));

                await topicClient.SendAsync(busMessage);

                await topicClient.CloseAsync();

                return Created(HttpContext.Request.Scheme + HttpContext.Request.Host.ToUriComponent(), "Success");
                //await _claimsService.SaveClaims(claimsRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Member record");
            }
        }
    }
}
