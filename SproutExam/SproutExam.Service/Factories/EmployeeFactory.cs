using SproutExam.Common.Enums;
using SproutExam.Service.LogicCollections;

namespace SproutExam.Service.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly IContractualEmployeeService _contractualEmployeeServiceService;
        private readonly IRegularEmployeeService _regularEmployeeService;

        public EmployeeFactory(IContractualEmployeeService contractualEmployeeServiceService, IRegularEmployeeService regularEmployeeService)
        {
            _contractualEmployeeServiceService = contractualEmployeeServiceService;
            _regularEmployeeService = regularEmployeeService;
        }

        public IEmployee Build(EmployeeType employeeType)
        {
            return employeeType switch
            {
                EmployeeType.Contractual => (IEmployee) _contractualEmployeeServiceService,
                EmployeeType.Regular => _regularEmployeeService,
                _ => null
            };
        }
    }
}
