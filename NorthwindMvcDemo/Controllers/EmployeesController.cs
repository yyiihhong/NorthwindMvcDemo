using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthwindMvcDemo.Interfaces.IServices;
using NorthwindMvcDemo.Models;
using NorthwindMvcDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindMvcDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly northwindContext _context;
        private readonly IEmployeesService _employeesService;

        public EmployeesController(northwindContext context, IEmployeesService employeesService)
        {
            _context = context;
            _employeesService = employeesService;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var emplyees = await _employeesService.GetAllEmployees();
            return View(emplyees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var details = await _employeesService.GetDetailsAsync(id.Value);

            if (details == null)
                return NotFound();

            return View(details);
        }

        // 顯示空白表單頁面
        public IActionResult Create()
        {
            ViewData["ReportsTo"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReportsTo"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", employees.ReportsTo);
            return View(employees);
        }

        // GET: 時進入編輯畫面
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
            ViewData["ReportsTo"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", employees.ReportsTo);
            return View(employees);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employees employees)
        {
            if (id != employees.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _employeesService.UpdateEmployeeAsync(employees);
                if (!success)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["ReportsTo"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", employees.ReportsTo);
            return View(employees);
        }

        // GET: 時進入刪除畫面
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employees
                .Include(e => e.ReportsToNavigation)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: 刪除資料列
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeesService.DeleteByIdAsync(id);

            if (!result)
            {
                TempData["ErrorMessage"] = "無法刪除：此員工仍有訂單紀錄。";
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = "員工已成功刪除。";
            return RedirectToAction(nameof(Index));
        }

    }
}
