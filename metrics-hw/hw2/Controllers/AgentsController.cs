using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            if (!IsAgentRegistered(agentInfo.AgentId))
            {
                _registeredAgents.Add(agentInfo);
                return Ok($"Зарегистрировано {agentInfo.AgentId} {agentInfo.AgentAddress}") ;
            } else
            {
                return BadRequest("Агент с таким Id уже зарегистрирован");
            }
            
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult ShowAll()
        {
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
