namespace Interest.Calculator.Application.Interfaces
{
    public interface ICalculateService
    {
        public double Calc(double initialValue, int months, double rate);
    }
}
