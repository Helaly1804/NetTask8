using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.DataAccess.Models
{
    public class FileField : BaseEntity
    {
        public string Subject { get; set; } 
        public int SubmittedById { get; set; } 
        public string Status { get; set; } 
        public DateTime FileDate { get; set; } 
        public string ResponsibleEmployee { get; set; } 
        public string FilePath { get; set; } 
        public int ApprovalId { get; set; }
        public Approval Approval { get; set; }
    }
}
