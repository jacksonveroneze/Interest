namespace Interest.Calculator.Application.Interfaces
{
    public interface ICalculateService
    {
        public double Calc(int initialValue, int months, double rate);
    }
}
