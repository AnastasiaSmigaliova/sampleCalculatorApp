using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Services;

namespace Tests
{
    public class CalculatorServiceTests
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorServiceTests()
        {
            _calculatorService = new CalculatorService();
        }

        [Fact]
        public void Add_ShouldReturnCorrectValue()
        {
            // Arrange
            double x = 4.125;
            double y = -0.1251;

            // Act
            var result = _calculatorService.Add(x, y);

            // Assert
            Assert.Equal(x + y, result);
        }

        [Fact]
        public void Add_ShouldThrowOverflowException_WhenResultIsTooLarge()
        {
            // Arrange
            double x = double.MaxValue;
            double y = double.MaxValue;

            // Act & Assert
            Assert.Throws<OverflowException>(() => _calculatorService.Add(x, y));
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectValue()
        {
            // Arrange
            double x = 4.125;
            double y = -0.1251;

            // Act
            var result = _calculatorService.Subtract(x, y);

            // Assert
            Assert.Equal(x - y, result);
        }

        [Fact]
        public void Subtract_ShouldThrowOverflowException_WhenResultIsTooSmall()
        {
            // Arrange
            double x = -double.MaxValue;
            double y = double.MaxValue;

            // Act & Assert
            Assert.Throws<OverflowException>(() => _calculatorService.Subtract(x, y));
        }
    }
}
