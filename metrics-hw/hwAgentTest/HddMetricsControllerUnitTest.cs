using hwAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using hwAgent.DAL;
using hwAgent.Models;
using Microsoft.Extensions.Logging;

namespace hwAgentTest
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;
        private Mock<IHddMetricsRepository> mockRepository;
        private Mock<ILogger<HddMetricsController>> mockLogger;

        public HddMetricsControllerUnitTests()
        {
            mockRepository = new Mock<IHddMetricsRepository>();
            mockLogger = new Mock<ILogger<HddMetricsController>>();
            controller = new HddMetricsController(mockLogger.Object, mockRepository.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mockRepository.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();

            var result = controller.Create(new hwAgent.Requests.HddMetricCreateRequest { Time = TimeSpan.FromSeconds(1).ToString(), Value = 50 });

            mockRepository.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtLeastOnce());
        }

        [Fact]
        public void GetHddLeft_ShouldCall_GetByTimePeriod_From_Repository()
        {
            var fromTime = TimeSpan.FromSeconds(32);
            var toTime = TimeSpan.FromSeconds(35);

            mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Verifiable();

            var result = controller.GetHddLeft(fromTime, toTime);

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
