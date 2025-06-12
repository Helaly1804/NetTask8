using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.BusinessLogic.DataTransferObjects.Approval
{
    public class ApprovalDto
    {
        public int Id { get; set; }
        public string ApproverName { get; set; }
        public int DecisionValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public int EmployeeId { get; set; }
    }
}
