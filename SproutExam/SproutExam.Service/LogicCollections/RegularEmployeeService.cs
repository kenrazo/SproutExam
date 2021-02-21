using SproutExam.Service.Constants;
using System;

namespace SproutExam.Service.LogicCollections
{
    public class RegularEmployeeService : IRegularEmployeeService
    {

        public double Compute(double absentDays)
        {
            var totalWorkDays = Math.Round(RegularEmployeeConstants.WorkingDays - absentDays, 2, MidpointRounding.AwayFromZero);
            var salary = RegularEmployeeConstants.BasicSalary - (RegularEmployeeConstants.BasicSalary / totalWorkDays) 
                - (RegularEmployeeConstants.BasicSalary * RegularEmployeeConstants.Tax);

            var totalSalary = Math.Round(salary, 2, MidpointRounding.AwayFromZero);

            return totalSalary;
        }
    }
}
