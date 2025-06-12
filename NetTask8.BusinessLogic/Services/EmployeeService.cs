using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetTask8.BusinessLogic.DataTransferObjects.Employee;
using NetTask8.DataAccess.Data.Context;
using NetTask8.DataAccess.Models;
using NetTask8.DataAccess.Repositories.Employees;
using System.Security.Cryptography;
using System.Text;

namespace NetTask8.BusinessLogic.Services
{
    public class EmployeeService(ApplicationDbContext dbContext, IMapper mapper, IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public async Task<EmployeeDto?> LoginAsync(string username, string password)
        {
            var hashedPassword = HashPassword(password);

            var employee = await dbContext.Employees
                .FirstOrDefaultAsync(e => e.Username == username && e.PasswordHash == hashedPassword);

            return employee is null ? null : mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            return employee is null ? null : mapper.Map<EmployeeDto>(employee);
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        public async Task<EmployeeDto?> ValidateLoginAsync(string username, string password)
        {
            var employee = await employeeRepository.GetByUsernameAsync(username);
            if (employee == null || employee.PasswordHash != password)
                return null;

            return mapper.Map<EmployeeDto>(employee);
        }


    }
}
