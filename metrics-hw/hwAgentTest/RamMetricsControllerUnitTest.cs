using hwAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using hwAgent.DAL;
using hwAgent.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Collections.Generic;

namespace hwAgentTest
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;
        private Mock<IRamMetricsRepository> mockRepository;
        private Mock<ILogger<RamMetricsController>> mockLogger;
        private Mock<IMapper> mockMapper;

        public RamMetricsControllerUnitTests()
        {
            mockRepository = new Mock<IRamMetricsRepository>();
            mockLogger = new Mock<ILogger<RamMetricsController>>();
            mockMapper = new Mock<IMapper>();
            controller = new RamMetricsController(mockLogger.Object, mockRepository.Object, mockMapper.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mockRepository.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();

            var result = controller.Create(new hwAgent.Requests.RamMetricCreateRequest { Time = TimeSpan.FromSeconds(1).ToString(), Value = 50 });

            mockRepository.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtLeastOnce());
        }

        [Fact]
        public void GetRamAvailable_ShouldCall_GetByTimePeriod_From_Repository()
        {
            var fromTime = TimeSpan.FromSeconds(32);
            var toTime = TimeSpan.FromSeconds(35);
            mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(new List<RamMetric>());

            var result = controller.GetRamAvailable(fromTime, toTime);

            mockRepository.Verify(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()), Times.Once);
        }

        [Fact]
        public void GetAll_ShouldCall_GetAll_From_Repository()
        {

            mockRepository.Setup(repository => repository.GetAll()).Returns(new List<RamMetric>());

            var result = controller.GetAll();

            mockRepository.Verify();
        }


    }
}
