using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.DataAccess.Models
{
    public class Approval
    {
        public int Id { get; set; }
        public int? FileFieldId { get; set; }
        public virtual FileField? FileField { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public string ApproverName { get; set; }
        public int DecisionValue { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
