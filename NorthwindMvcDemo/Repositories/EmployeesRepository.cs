using Microsoft.EntityFrameworkCore;
using NorthwindMvcDemo.Interfaces.IRepositories;
using NorthwindMvcDemo.Models;

namespace NorthwindMvcDemo.Repositories
{
    public class EmployeesRepository: IEmployeesRepository
    {
        private readonly northwindContext _context;

        public EmployeesRepository(northwindContext context)
        {
            _context = context;
        }

        public async Task<List<Employees>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employees> GetByIdAsync(int id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task AddAsync(Employees employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}
