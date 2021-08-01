using hwAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using hwAgent.DAL;
using hwAgent.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace hwAgentTest
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController controller;
        private Mock<ICpuMetricsRepository> mockRepository;
        private Mock<ILogger<CpuMetricsController>> mockLogger;

        public CpuMetricsControllerUnitTests()
        {
            mockRepository = new Mock<ICpuMetricsRepository>();
            mockLogger = new Mock<ILogger<CpuMetricsController>>();
            controller = new CpuMetricsController(mockLogger.Object, mockRepository.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mockRepository.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            var result = controller.Create(new hwAgent.Requests.CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1).ToString(), Value = 50 });

            mockRepository.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtLeastOnce());
        }

        [Fact]
        public void GetCpuMetrics_ShouldCall_GetByTimePeriod_From_Repository()
        {
            var fromTime = TimeSpan.FromSeconds(32);
            var toTime = TimeSpan.FromSeconds(35);

            mockRepository.Setup(repository =>repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Verifiable();

            var result = controller.GetCpuMetrics(fromTime, toTime);

            mockRepository.Verify(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()), Times.Once);
        }

        [Fact]
        public void GetAll_ShouldCall_GetAll_From_Repository()
        {

            mockRepository.Setup(repository => repository.GetAll()).Verifiable();

            var result = controller.GetAll();

            mockRepository.Verify();
        }


    }
}
