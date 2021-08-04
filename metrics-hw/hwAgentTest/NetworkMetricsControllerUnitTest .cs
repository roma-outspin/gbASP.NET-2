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
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController controller;
        private Mock<INetworkMetricsRepository> mockRepository;
        private Mock<ILogger<NetworkMetricsController>> mockLogger;
        private Mock<IMapper> mockMapper;

        public NetworkMetricsControllerUnitTests()
        {
            mockRepository = new Mock<INetworkMetricsRepository>();
            mockLogger = new Mock<ILogger<NetworkMetricsController>>();
            mockMapper = new Mock<IMapper>();
            controller = new NetworkMetricsController(mockLogger.Object, mockRepository.Object, mockMapper.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            mockRepository.Setup(repository => repository.Create(It.IsAny<NetworkMetric>())).Verifiable();

            var result = controller.Create(new hwAgent.Requests.NetworkMetricCreateRequest { Time = TimeSpan.FromSeconds(1).ToString(), Value = 50 });

            mockRepository.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtLeastOnce());
        }

        [Fact]
        public void GetNetworkMetrics_ShouldCall_GetByTimePeriod_From_Repository()
        {
            var fromTime = TimeSpan.FromSeconds(32);
            var toTime = TimeSpan.FromSeconds(35);

            mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(new List<NetworkMetric>());

            var result = controller.GetNetworkMetrics(fromTime, toTime);

            mockRepository.Verify(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()), Times.Once);
        }

        [Fact]
        public void GetAll_ShouldCall_GetAll_From_Repository()
        {

            mockRepository.Setup(repository => repository.GetAll()).Returns(new List<NetworkMetric>());

            var result = controller.GetAll();

            mockRepository.Verify();
        }

    }
}
