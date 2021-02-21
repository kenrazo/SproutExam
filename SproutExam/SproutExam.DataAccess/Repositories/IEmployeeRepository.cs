using SproutExam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SproutExam.DataAccess.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Employee>> Get();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Employee> GetById(Guid id);

        /// <summary>
        /// Adds the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        Task Add(Employee employee);
    }
}
