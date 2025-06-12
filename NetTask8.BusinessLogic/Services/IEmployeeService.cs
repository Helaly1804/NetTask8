using NetTask8.BusinessLogic.DataTransferObjects.Employee;
using System.Threading.Tasks;

namespace NetTask8.BusinessLogic.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto?> LoginAsync(string username, string password);
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<EmployeeDto?> ValidateLoginAsync(string username, string password);
    }
}

