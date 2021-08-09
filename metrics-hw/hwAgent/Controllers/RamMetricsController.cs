using AutoMapper;
using hwAgent.DAL;
using hwAgent.Models;
using hwAgent.Requests;
using hwAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RamMetricsController> _logger;
        private IRamMetricsRepository repository;
        private IMapper mapper;

        public RamMetricsController(ILogger<RamMetricsController> logger, IRamMetricsRepository repository, IMapper mapper)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в RamMetricsController-Agent");
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetRamAvailable(TimeSpan fromTime, TimeSpan toTime)
        {
            _logger.LogInformation($"GetRamAvailable fromTime={fromTime} toTime={toTime}");
            var metrics = repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };


                foreach (var metric in metrics)
                {
                    response.Metrics.Add(mapper.Map<RamMetricDto>(metric));
                }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            _logger.LogInformation($"Try to create RamMetric with Time={request.Time}, Value={request.Value}");
            repository.Create(mapper.Map<RamMetric>(request));

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _logger.LogInformation($"Был вызван метод Getall()");
            var metrics = repository.GetAll();

            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };

                foreach (var metric in metrics)
                {
                    response.Metrics.Add(mapper.Map<RamMetricDto>(metric));
                }

            return Ok(response);
        }



    }
}
