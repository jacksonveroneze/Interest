﻿using System;
using Interest.Calculator.Application.Exceptions;
using Interest.Calculator.Application.Interfaces;

namespace Interest.Calculator.Application.Services
{
    public class CalculateService : ICalculateService
    {
        //
        // Summary:
        //     /// Method responsible for execute calc. ///
        //
        // Parameters:
        //   initialValue:
        //     The initialValue param.
        //
        //   months:
        //     The months param.
        //
        //   rate:
        //     The rate param.
        //
        public double Calc(double initialValue, int months, double rate)
        {
            if (initialValue <= 0)
                throw new ApplicationCalculatorException("O valor inicial deve ser maior que zero.");

            if (months <= 0)
                throw new ApplicationCalculatorException("O total de meses deve ser maior que zero.");

            if (rate < 0)
                throw new ApplicationCalculatorException("A taxa de juros deve maior ou igual a zero.");

            double calcResult = initialValue * Math.Pow((1 + rate), months);

            return Math.Round(calcResult, 2, MidpointRounding.ToPositiveInfinity);
        }
    }
}
