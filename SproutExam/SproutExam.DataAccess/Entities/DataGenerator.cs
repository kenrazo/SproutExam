using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SproutExam.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SproutExam.DataAccess.Entities
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new EmployeeDbContext(serviceProvider.GetRequiredService<DbContextOptions<EmployeeDbContext>>());
            if (context.Employee.Any())
            {
                return;   // Data was already seeded
            }

            context.Employee.Add(new Employee
            {
                Firstname = "Coco",
                Lastname = "Melon",
                Tin = "123-456-789",
                EmployeeType = 1,
                Id = new Guid()
            });

            context.SaveChanges();
        }
    }
}
