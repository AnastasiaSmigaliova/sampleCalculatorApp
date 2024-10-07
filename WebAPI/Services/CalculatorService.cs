namespace WebAPI.Services
{
    public class CalculatorService : ICalculatorService
    {

        public double Add(double x, double y)
        {
            double result = x + y;
            ValidateResult(result);
            return result;
        }

        public double Subtract(double x, double y)
        {
            double result = x - y;
            ValidateResult(result);
            return result;
        }

        private void ValidateResult(double result)
        {
            if (double.IsInfinity(result))
            {
                throw new OverflowException("The result is too large.");
            }
        }
    }
}