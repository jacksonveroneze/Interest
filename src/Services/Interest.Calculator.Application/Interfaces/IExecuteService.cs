﻿using System.Threading.Tasks;
using Interest.Calculator.Application.Models;

namespace Interest.Calculator.Application.Interfaces
{
    public interface IExecuteService
    {
        Task<CalculationResponse> Execute(int initialValue, int months);
    }
}
