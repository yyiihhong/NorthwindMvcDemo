using NorthwindMvcDemo.Models;

namespace NorthwindMvcDemo.Interfaces.IRepositories
{
    public interface IEmployeesRepository
    {
        Task<List<Employees>> GetAllAsync();
    }
}
