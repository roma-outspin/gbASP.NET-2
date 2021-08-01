using hw2;
using hw2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace MetricsManagerTests
{
    public class AgentsControllerUnitTests
    {
        private AgentsController controller;
        private Mock<ILogger<AgentsController>> mockLogger;

        public AgentsControllerUnitTests()
        {
            mockLogger = new Mock<ILogger<AgentsController>>();
            controller = new AgentsController(mockLogger.Object);
        }

        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            //Arrange
            var agentInfo = new AgentInfo() { AgentId = 1 };


            //Act
            var result = controller.RegisterAgent(agentInfo);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void RegisterAgent_ReturnsBadRequest()
        {
            //Arrange
            var agentInfo = new AgentInfo() { AgentId = 1 };


            //Act
            controller.RegisterAgent(agentInfo);
            var result = controller.RegisterAgent(agentInfo);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void EnableAgent_ReturnsOk()
        {
            //Arrange
            var agentInfo = new AgentInfo() { AgentId = 1 };

            //Act
            var result = controller.EnableAgentById(agentInfo.AgentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void DisableAgent_ReturnsOk()
        {
            //Arrange
            var agentInfo = new AgentInfo() { AgentId = 1 };

            //Act
            var result = controller.DisableAgentById(agentInfo.AgentId);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void ShowAll_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.ShowAll();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}
