using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly static List<AgentInfo> _registeredAgents = new();
        private readonly ILogger<AgentsController> _logger;

        public AgentsController(ILogger<AgentsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в AgentsController");
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            if (!IsAgentRegistered(agentInfo.AgentId))
            {
                _registeredAgents.Add(agentInfo);
                _logger.LogInformation($"RegisterAgent ID={agentInfo.AgentId} Url={agentInfo.AgentAddress}");

                return Ok($"Зарегистрировано {agentInfo.AgentId} {agentInfo.AgentAddress}") ;
            } else
            {
                _logger.LogInformation($"RegisterAgent Error ID={agentInfo.AgentId} Url={agentInfo.AgentAddress} Агент с таким Id уже зарегистрирован");
                return BadRequest("Агент с таким Id уже зарегистрирован");
            }
            
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation($"EnableAgentById ID={agentId}");
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation($"DisableAgentById ID={agentId}");
            return Ok();
        }

        [HttpGet]
        public IActionResult ShowAll()
        {
            _logger.LogInformation($"ShowAll");
            return Ok(_registeredAgents);
        }

        private  static bool IsAgentRegistered(int agentId)
        {
            foreach(var agent in _registeredAgents)
            {
                if (agent.AgentId==agentId)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
