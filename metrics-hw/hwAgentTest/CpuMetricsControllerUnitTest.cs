using hwAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace hwAgentTest
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController controller;

        public CpuMetricsControllerUnitTests()
        {
            controller = new CpuMetricsController();
        }

        [Fact]
        public void GetCPUMetrics_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //Act
            var result = controller.GetCpuMetrics(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


    }
}
