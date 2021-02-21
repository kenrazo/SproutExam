using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SproutExam.DataAccess.DataContext;
using SproutExam.DataAccess.Repositories;
using SproutExam.Service.Factories;
using SproutExam.Service.LogicCollections;
using SproutExam.Service.MapperProfiles;
using System.Reflection;

namespace SproutExam.Extensions
{
    public static class StartupExtension
    {
        public static IServiceCollection InjectAutoMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(MainProfile).GetTypeInfo().Assembly);
        }

        public static IServiceCollection InjectServices(this IServiceCollection services)
        { 
            services.AddTransient<IEmployeeFactory, EmployeeFactory>();
            services.AddTransient<IRegularEmployeeService, RegularEmployeeService>();
            services.AddTransient<IContractualEmployeeService, ContractualEmployeeService>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            return services;
        }

        public static IServiceCollection InjectDbContext(this IServiceCollection services)
        {
           return services.AddDbContext<EmployeeDbContext>(options => options.UseInMemoryDatabase(databaseName: "Employee"));
        }

        public static IServiceCollection InjectRepository(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
    
}
