using Microsoft.EntityFrameworkCore;
using SproutExam.DataAccess.DataContext;
using SproutExam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SproutExam.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task Add(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetById(Guid id)
        {
            return await _context.Employee.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
