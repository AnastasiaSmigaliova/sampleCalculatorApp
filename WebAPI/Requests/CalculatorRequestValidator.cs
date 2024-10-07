using FluentValidation;
using System.Text.RegularExpressions;

namespace WebAPI.Requests
{
    public class CalculatorRequestValidator : AbstractValidator<CalculatorRequest>
    {
        public CalculatorRequestValidator()
        {
            RuleFor(calculatorRequest => calculatorRequest.X)
                .NotEmpty()
                .WithMessage("Value must not be empty.")
                .Must(BeAValidDouble)
                .WithMessage("Value must be a valid number of type double.");
            RuleFor(calculatorRequest => calculatorRequest.Y)
                .NotEmpty()
                .WithMessage("Value must not be empty.")
                .Must(BeAValidDouble)
                .WithMessage("Value must be a valid number of type double.");
        }

        private bool BeAValidDouble(string value)
        {
            return double.TryParse(value, out _);
        }
    }
}
