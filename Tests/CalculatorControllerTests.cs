using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using WebAPI.Requests;
using Moq;
using WebAPI.Services;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using WebAPI.Responses;

namespace Tests
{
    public class CalculatorControllerTests
    {
        private readonly Mock<ICalculatorService> _mockCalculatorService;
        private readonly CalculatorController _controller;

        public CalculatorControllerTests()
        {
            _mockCalculatorService = new Mock<ICalculatorService>();
            _controller = new CalculatorController(_mockCalculatorService.Object);
        }

        [Fact]
        public void Add_ShouldReturnOkWithCorrectResult()
        {
            // Arrange
            double x = 1.1512;
            double y = 5.215;
            double sum = x + y;

            var request = new CalculatorRequest
            {
                X = x.ToString(),
                Y = y.ToString()
            };
            _mockCalculatorService.Setup(s => s.Add(x, y)).Returns(sum);

            // Act
            var result = _controller.Add(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(sum, okResult.Value);
        }

        [Fact]
        public void Add_ShouldReturnBadRequest_WhenOverflowExceptionThrown()
        {
            // Arrange
            double x = 1.1512;
            double y = 5.215;

            var request = new CalculatorRequest
            {
                X = x.ToString(),
                Y = y.ToString()
            };
            _mockCalculatorService.Setup(s => s.Add(x, y)).Throws(new OverflowException("Overflow occurred"));

            // Act
            var result = _controller.Add(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            var errorResponse = Assert.IsType<ErrorResponse>(badRequestResult.Value);
            Assert.Equal("Overflow occurred", errorResponse.Message);
        }

        [Fact]
        public void Add_ShouldReturnBadRequest_WhenInvalidInput()
        {
            // Arrange
            double y = 5.215;
            var request = new CalculatorRequest { X = "invalid", Y = y.ToString() };

            // Act & Assert
            Assert.Throws<FormatException>(() => _controller.Add(request));
        }

        [Fact]
        public void Subtract_ShouldReturnOk_WithCorrectResult()
        {
            // Arrange
            double x = 1.1512;
            double y = 5.215;
            double difference = x - y;

            var request = new CalculatorRequest
            {
                X = x.ToString(),
                Y = y.ToString()
            };
            _mockCalculatorService.Setup(s => s.Subtract(x, y)).Returns(difference);

            // Act
            var result = _controller.Subtract(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(difference, okResult.Value);
        }

        [Fact]
        public void Subtract_ShouldReturnBadRequest_WhenOverflowExceptionThrown()
        {
            // Arrange
            double x = 1.1512;
            double y = 5.215;

            var request = new CalculatorRequest
            {
                X = x.ToString(),
                Y = y.ToString()
            };
            _mockCalculatorService.Setup(s => s.Subtract(x, y)).Throws(new OverflowException("Overflow occurred"));

            // Act
            var result = _controller.Subtract(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            var errorResponse = Assert.IsType<ErrorResponse>(badRequestResult.Value);
            Assert.Equal("Overflow occurred", errorResponse.Message);
        }

        [Fact]
        public void Subtract_ShouldReturnBadRequest_WhenInvalidInput()
        {
            // Arrange
            double y = 5.215;
            var request = new CalculatorRequest { X = "invalid", Y = y.ToString() };

            // Act & Assert
            Assert.Throws<FormatException>(() => _controller.Subtract(request));
        }
    }
}

