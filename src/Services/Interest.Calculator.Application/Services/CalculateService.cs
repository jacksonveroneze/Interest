using System;

namespace Interest.Calculator.Application.Services
{
    public class CalculateService
    {
        public double Calc(int initialValue, int months, double rate)
        {
            if (initialValue <= 0)
                throw new Exception("O valor inicial deve ser maior que zero.");

            if (months <= 0)
                throw new Exception("O total de meses deve ser maior que zero.");

            if (rate < 0)
                throw new Exception("A taxa de juros deve maior ou igual a zero.");

            double calcResult = initialValue * Math.Pow((1 + rate), months);

            return Math.Round(calcResult, 2);
        }
    }
}
