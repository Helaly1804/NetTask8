using NetTask8.DataAccess.Models;

namespace NetTask8.DataAccess.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByUsernameAndPasswordAsync(string username, string passwordHash);
        Task<Employee?> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task<Employee?> GetByUsernameAsync(string username);
    }
}

