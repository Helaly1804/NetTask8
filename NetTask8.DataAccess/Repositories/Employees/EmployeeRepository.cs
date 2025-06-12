using Microsoft.EntityFrameworkCore;
using NetTask8.DataAccess.Data.Context;
using NetTask8.DataAccess.Models;

namespace NetTask8.DataAccess.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Employee?> GetByUsernameAndPasswordAsync(string username, string passwordHash)
        {
            return await _db.Employees
                .FirstOrDefaultAsync(e => e.Username == username && e.PasswordHash == passwordHash);
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _db.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task AddAsync(Employee employee)
        {
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
        }

        public async Task<Employee?> GetByUsernameAsync(string username)
        {
            return await _db.Employees.FirstOrDefaultAsync(e => e.Username == username);
        }
    }
}

