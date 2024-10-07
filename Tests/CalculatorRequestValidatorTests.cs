using WebAPI.Requests;
using FluentValidation.TestHelper;

namespace Tests
{
    public class CalculatorRequestValidatorTests
    {

        private readonly CalculatorRequestValidator _validator;

        public CalculatorRequestValidatorTests()
        {
            _validator = new CalculatorRequestValidator();
        }

        [Fact]
        public void ShouldHaveError_WhenXIsEmpty()
        {
            // Arrange
            var request = new CalculatorRequest { X = "", Y = "5" };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(r => r.X)
                  .WithErrorMessage("Value must not be empty.");
        }

        [Fact]
        public void ShouldHaveError_WhenYIsEmpty()
        {
            // Arrange
            var request = new CalculatorRequest { X = "5", Y = "" };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(r => r.Y)
                  .WithErrorMessage("Value must not be empty.");
        }

        [Fact]
        public void ShouldHaveError_WhenXIsNotAValidDouble()
        {
            // Arrange
            double y = 10.312;
            var request = new CalculatorRequest { X = "invalid", Y = y.ToString() };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(r => r.X)
                  .WithErrorMessage("Value must be a valid number of type double.");
        }

        [Fact]
        public void ShouldHaveError_WhenYIsNotAValidDouble()
        {
            // Arrange
            double x = 10.312;
            var request = new CalculatorRequest { X = x.ToString(), Y = "invalid" };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(r => r.Y)
                  .WithErrorMessage("Value must be a valid number of type double.");
        }

        [Fact]
        public void ShouldNotHaveError_WhenXAndYAreValidDoubles()
        {
            // Arrange
            double x = 10.312;
            double y = -2.425;
            var request = new CalculatorRequest
            {
                X = x.ToString(),
                Y = y.ToString()
            };

            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
