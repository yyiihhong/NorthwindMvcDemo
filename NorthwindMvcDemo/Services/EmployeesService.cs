using NorthwindMvcDemo.Interfaces.IRepositories;
using NorthwindMvcDemo.Interfaces.IServices;
using NorthwindMvcDemo.Models;
using NorthwindMvcDemo.ViewModel;
using NuGet.Protocol.Core.Types;

namespace NorthwindMvcDemo.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
        public async Task<List<EmployeesViewModel>> GetAllEmployees()
        {
            var employees = await _employeesRepository.GetAllAsync();
            return employees.Select(e => new EmployeesViewModel
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title,
                Address = e.Address,
                City = e.City,
                BirthDate = e.BirthDate?.ToString("yyyy/MM/dd"),
                HireDate = e.HireDate?.ToString("yyyy/MM/dd")
            }).ToList(); ;
        }

        public async Task<Employees> GetDetailsAsync(int id)
        {
            var employee = await _employeesRepository.GetByIdAsync(id);
            if (employee == null)
                return null;
            return employee;
        }

        public async Task CreateEmployeeAsync(Employees employee)
        {
            // 可以加入商業邏輯驗證，例如檢查是否重複等
            await _employeesRepository.AddAsync(employee);
        }
    }
}
