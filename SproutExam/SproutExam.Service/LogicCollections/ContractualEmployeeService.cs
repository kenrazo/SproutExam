using SproutExam.Service.Constants;
using System;

namespace SproutExam.Service.LogicCollections
{
    public class ContractualEmployeeService : IContractualEmployeeService
    {
        public double Compute(double totalWorkDays)
        {       
            var totalSalary = Math.Round(ContractualEmployeeConstants.SalaryPerDay * totalWorkDays, 2, MidpointRounding.AwayFromZero);

            return totalSalary;
        }
    }
}
