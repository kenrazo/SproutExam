using AutoMapper;
using SproutExam.DataAccess.Repositories;

namespace SproutExam.Service.LogicCollections
{
    public abstract class BaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IEmployeeRepository _employeeRepository;

        public BaseService(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
    }
}
