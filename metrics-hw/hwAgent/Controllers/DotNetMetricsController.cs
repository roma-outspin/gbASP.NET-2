using AutoMapper;
using hwAgent.DAL;
using hwAgent.Models;
using hwAgent.Requests;
using hwAgent.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace hwAgent.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private IDotNetMetricsRepository repository;
        private IMapper mapper;


        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IDotNetMetricsRepository repository, IMapper mapper)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController-Agent");
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrorsCount(TimeSpan fromTime, TimeSpan toTime)
        {
            _logger.LogInformation($"GetErrorsCount fromTime={fromTime} toTime={toTime}");
            var metrics = repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

                foreach (var metric in metrics)
                {
                    response.Metrics.Add(mapper.Map<DotNetMetricDto>(metric));
                }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _logger.LogInformation($"Try to create DotNetMetric with Time={request.Time}, Value={request.Value}");

            repository.Create(mapper.Map<DotNetMetric>(request));

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _logger.LogInformation($"Был вызван метод Getall()");
            var metrics = repository.GetAll();

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

                foreach (var metric in metrics)
                {
                    response.Metrics.Add(mapper.Map<DotNetMetricDto>(metric));
                }


            return Ok(response);
        }
    }
}
