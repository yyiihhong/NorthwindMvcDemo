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
    }
}
