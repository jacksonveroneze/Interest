namespace Interest.Calculator.Application.Interfaces
{
    public interface ICalculateService
    {
        public double Calc(double initialValue, double months, double rate);
    }
}
