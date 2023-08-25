using GitHubActionPlayGround.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace GitHubActionPlayGroundTest
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void WeatherForecastController_Get_ShouldReturnWeather()
        {
            // Arrange
            var _loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(_loggerMock.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Summary);
            Assert.InRange(result.TemperatureC, -20, 55);

        }
    }
}