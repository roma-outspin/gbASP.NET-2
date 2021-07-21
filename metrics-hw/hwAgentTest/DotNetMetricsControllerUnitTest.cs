using hwAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace hwAgentTest
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController controller;

        public DotNetMetricsControllerUnitTests()
        {
            controller = new DotNetMetricsController();
        }

        [Fact]
        public void GetDotNetErrorCount_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //Act
            var result = controller.GetErrorsCount(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


    }
}
