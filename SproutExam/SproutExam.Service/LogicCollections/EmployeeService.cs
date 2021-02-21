using AutoMapper;
using SproutExam.Common.Enums;
using SproutExam.DataAccess.Entities;
using SproutExam.DataAccess.Repositories;
using SproutExam.Service.Dtos;
using SproutExam.Service.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SproutExam.Service.LogicCollections
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeFactory _employeeFactory;
        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository,
            IEmployeeFactory employeeFactory)
            : base(mapper, employeeRepository)
        {
            _employeeFactory = employeeFactory;
        }

        /// <summary>
        /// Get all employee.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeOutputDto>> Get()
        {
            var data = await _employeeRepository.Get();

            if (!data.Any())
                throw new Exception("Employees not found");

            return _mapper.Map<IEnumerable<EmployeeOutputDto>>(data);
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EmployeeOutputDto> GetById(Guid id)
        {
            var data = await _employeeRepository.GetById(id);

            if (data == null)
                throw new Exception("Employee not found");

            return _mapper.Map<EmployeeOutputDto>(data);
        }

        /// <summary>
        /// Add employee.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<EmployeeOutputDto> Add(EmployeeInputDto employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Employee is null");

            if (string.IsNullOrEmpty(employee.Firstname) || string.IsNullOrEmpty(employee.Lastname)
                || string.IsNullOrEmpty(employee.Tin))
                throw new Exception("Parameter has null or empty values");

            var employeeEntity = _mapper.Map<Employee>(employee);

            employeeEntity.Id = new Guid();

            await _employeeRepository.Add(employeeEntity);

            return _mapper.Map<EmployeeOutputDto>(employeeEntity);
        }

        public async Task<double> ComputeSalary(double inputToBeCompute, int employeeType)
        {
            var employeeComputation = _employeeFactory.Build((EmployeeType)employeeType);

            return employeeComputation.Compute(inputToBeCompute);
        }
    }
}
