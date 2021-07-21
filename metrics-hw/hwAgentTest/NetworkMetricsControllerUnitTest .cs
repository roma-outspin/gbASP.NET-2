using hwAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace hwAgentTest
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController controller;

        public NetworkMetricsControllerUnitTests()
        {
            controller = new NetworkMetricsController();
        }

        [Fact]
        public void GetNetworkMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //Act
            var result = controller.GetNetworkMetrics(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


    }
}
