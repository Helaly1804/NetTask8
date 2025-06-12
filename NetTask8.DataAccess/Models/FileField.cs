using NetTask8.DataAccess.Models.Enums;
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
        public virtual Employee Employee { get; set; }
        public FileStatus Status { get; set; } = FileStatus.Pending;
        public DateTime FileDate { get; set; } 
        public string ResponsibleEmployee { get; set; } 
        public string FilePath { get; set; }
        public virtual ICollection<Approval> Approvals { get; set; } = new List<Approval>();
    }
}
