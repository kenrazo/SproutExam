using SproutExam.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SproutExam.Service.LogicCollections
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get employee list.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EmployeeOutputDto>> Get();

        /// <summary>
        /// Get employee by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<EmployeeOutputDto> GetById(Guid id);

        /// <summary>
        /// Adds the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        Task<EmployeeOutputDto> Add(EmployeeInputDto employee);

        /// <summary>
        /// Computes the salary.
        /// </summary>
        /// <param name="inputToBeCompute">The input to be compute.</param>
        /// <param name="employeeType">Type of the employee.</param>
        /// <returns></returns>
        Task<double> ComputeSalary(double inputToBeCompute, int employeeType);

    }
}
