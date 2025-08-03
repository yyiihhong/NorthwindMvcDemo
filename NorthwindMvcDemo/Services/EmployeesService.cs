using NorthwindMvcDemo.Interfaces.IRepositories;
using NorthwindMvcDemo.Interfaces.IServices;
using NorthwindMvcDemo.Models;
using NorthwindMvcDemo.ViewModel;
using NuGet.Protocol.Core.Types;

namespace NorthwindMvcDemo.Services
{
    public class EmployeesService: IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
        public async Task<List<EmployeesViewModel>> GetAllEmployees()
        {
            var employees = await _employeesRepository.GetAllAsync();
            return  employees.Select(e => new EmployeesViewModel
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title,
                Address = e.Address,
                City = e.City,
                BirthDate = e.BirthDate?.ToString("yyyy/MM/dd"),
                HireDate = e.HireDate?.ToString("yyyy/MM/dd")
            }).ToList(); ;
        }
    }
}
