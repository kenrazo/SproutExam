using AutoMapper;
using SproutExam.DataAccess.Entities;
using SproutExam.Service.Dtos;

namespace SproutExam.Service.MapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            MappingProfile();
        }

        private void MappingProfile()
        {
            CreateMap<EmployeeInputDto, Employee>().ReverseMap();
            CreateMap<EmployeeOutputDto, Employee>().ReverseMap();
        }
    }
}
