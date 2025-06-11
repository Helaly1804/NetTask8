using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.DataAccess.Models
{
    public class Employee : BaseEntity
    {       
        public string Role { get; set; } //Employee 1 , Employee 2 , Employee 3
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
