using SproutExam.Common.Enums;
using SproutExam.Service.LogicCollections;

namespace SproutExam.Service.Factories
{
    public interface IEmployeeFactory
    {
        IEmployee Build(EmployeeType employeeType);
    }
}
