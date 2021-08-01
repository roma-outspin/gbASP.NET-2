using hwAgent.Controllers;
using hwAgent.DAL;
using hwAgent.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace hwAgentTest
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController controller;
        private Mock<IDotNetMetricsRepository> mockRepository;
        private Mock<ILogger<DotNetMetricsController>> mockLogger;

        public DotNetMetricsControllerUnitTests()
        {
            mockRepository = new Mock<IDotNetMetricsRepository>();
            mockLogger = new Mock<ILogger<DotNetMetricsController>>();
            controller = new DotNetMetricsController(mockLogger.Object, mockRepository.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mockRepository.Setup(repository => repository.Create(It.IsAny<DotNetMetric>())).Verifiable();

            var result = controller.Create(new hwAgent.Requests.DotNetMetricCreateRequest { Time = TimeSpan.FromSeconds(1).ToString(), Value = 50 });

            mockRepository.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtLeastOnce());
        }

        [Fact]
        public void GetDotNetMetrics_ShouldCall_GetByTimePeriod_From_Repository()
        {
            var fromTime = TimeSpan.FromSeconds(32);
            var toTime = TimeSpan.FromSeconds(35);

            mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Verifiable();

            var result = controller.GetErrorsCount(fromTime, toTime);

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
