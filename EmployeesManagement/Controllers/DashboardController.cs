using EmployeesManagement.Data;
using EmployeesManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagement.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            DashboardViewModel model = new DashboardViewModel
            {
                // Total Employees
                TotalEmployees = await _context.employees.CountAsync(),

                // Distinct Departments
                TotalDepartments = await _context.employees
                                    .Select(e => e.Department)
                                    .Distinct()
                                    .CountAsync(),

                // Distinct Designations
                TotalDesignations = await _context.employees
                                    .Select(e => e.Designation)
                                    .Distinct()
                                    .CountAsync(),

                // Latest 5 Employees
                RecentEmployees = await _context.employees
                                    .OrderByDescending(e => e.Id)
                                    .Take(5)
                                    .ToListAsync()
            };

            return View(model);
        }
    }
}