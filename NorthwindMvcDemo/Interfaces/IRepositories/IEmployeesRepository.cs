using NorthwindMvcDemo.Models;

namespace NorthwindMvcDemo.Interfaces.IRepositories
{
    public interface IEmployeesRepository
    {
        Task<List<Employees>> GetAllAsync();
        Task<Employees> GetByIdAsync(int id);
        Task AddAsync(Employees employee);
        Task<bool> ExistsAsync(int id);
        Task UpdateAsync(Employees employee);
        Task DeleteAsync(Employees employee);
    }
}
