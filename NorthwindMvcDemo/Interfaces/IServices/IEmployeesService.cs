using NorthwindMvcDemo.Models;
using NorthwindMvcDemo.ViewModel;

namespace NorthwindMvcDemo.Interfaces.IServices
{
    public interface IEmployeesService
    {
        Task<List<EmployeesViewModel>> GetAllEmployees();
    }
}
