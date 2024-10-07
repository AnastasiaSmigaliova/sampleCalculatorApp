namespace WebAPI.Services
{
    public class CalculatorService : ICalculatorService
    {

        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Substract(double x, double y)
        {
            return x - y;
        }
    }
}
