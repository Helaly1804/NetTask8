using NetTask8.DataAccess.Models.Enums;

namespace NetTask8.BusinessLogic.DataTransferObjects.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeRole Role { get; set; }
        public string Username { get; set; }
    }
}

