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

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Employees.AnyAsync(e => e.EmployeeID == id);
        }
        public async Task UpdateAsync(Employees employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Employees employee)
        {
            bool hasOrders = await _context.Orders.AnyAsync(o => o.EmployeeID == employee.EmployeeID);

            if (hasOrders)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
