using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTask8.DataAccess.Models;

namespace NetTask8.DataAccess.Repositories.Approvals
{
    public interface IApprovalRepository
    {
        Task<Approval> AddAsync(Approval approval);
        Task<IEnumerable<Approval>> GetByFileIdAsync(int fileId);
    }
}
