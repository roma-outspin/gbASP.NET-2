using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwAgent.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetRamAvailable(TimeSpan fromTime, TimeSpan toTime)
        {
            return Ok("RAM work`s!");
        }

    }
}
