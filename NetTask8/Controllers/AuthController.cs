using Microsoft.AspNetCore.Mvc;
using NetTask8.BusinessLogic.Services;
using NetTask8.Presentation.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NetTask8.DataAccess.Repositories.Employees;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NetTask8.DataAccess.Models.Enums;

namespace NetTask8.Presentation.Controllers
{
    public class AuthController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;

        public AuthController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var hash = ComputeHash(password);
            var employee = await _employeeRepo.GetByUsernameAndPasswordAsync(username, hash);

            if (employee == null || (employee.Role != EmployeeRole.Employee2 && employee.Role != EmployeeRole.Employee3))
            {
                ModelState.AddModelError("", "Invalid credentials or not authorized.");
                return View();
            }

            HttpContext.Session.SetInt32("EmployeeId", employee.Id);
            HttpContext.Session.SetString("Role", employee.Role.ToString());
            HttpContext.Session.SetString("Name", employee.Name);

            return RedirectToAction("Index", "File");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private string ComputeHash(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}


