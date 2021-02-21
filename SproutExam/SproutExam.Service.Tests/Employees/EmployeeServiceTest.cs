using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SproutExam.DataAccess.Repositories;
using SproutExam.Service.Factories;
using SproutExam.Service.LogicCollections;
using SproutExam.Service.MapperProfiles;
using System.Threading.Tasks;

namespace SproutExam.Service.Tests.Employees
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        private Mock<IEmployeeFactory> _moqEmployeeFactory;
        private Mock<IEmployeeRepository> _moqEmployeeRepository;
        private IMapper _moqMapper;

        [SetUp]
        public void SetUpResources()
        {
            var myProfile = new MainProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            _moqMapper = mapper;
            _moqEmployeeFactory = new Mock<IEmployeeFactory>();
            _moqEmployeeRepository = new Mock<IEmployeeRepository>();
        }

        [Test]
        public async Task Compute_ShouldReturnCorrectSalary_RegularEmployee()
        {
            var expectedResult = 16690.91;

            _moqEmployeeFactory.Setup(m => m.Build(Common.Enums.EmployeeType.Regular)).Returns(new RegularEmployeeService());

            var employeeService = new EmployeeService(_moqMapper, _moqEmployeeRepository.Object,
                _moqEmployeeFactory.Object);

            var result = await employeeService.ComputeSalary(0, (int)Common.Enums.EmployeeType.Regular);

            result.Should().Be(expectedResult);
        }

        [Test]
        public async Task Compute_ShouldReturnCorrectSalary_ContractualEmployee()
        {
            var expectedResult = 7750.00;

            _moqEmployeeFactory.Setup(m => m.Build(Common.Enums.EmployeeType.Contractual)).Returns(new RegularEmployeeService());

            var employeeService = new EmployeeService(_moqMapper, _moqEmployeeRepository.Object, _moqEmployeeFactory.Object);

            var result = await employeeService.ComputeSalary(1, (int)Common.Enums.EmployeeType.Contractual);

            result.Should().Equals(expectedResult);
        }
    }
}
