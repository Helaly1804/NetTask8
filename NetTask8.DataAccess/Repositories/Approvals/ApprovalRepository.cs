using Microsoft.EntityFrameworkCore;
using NetTask8.DataAccess.Data.Context;
using NetTask8.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.DataAccess.Repositories.Approvals
{
    public class ApprovalRepository(ApplicationDbContext dbContext) : IApprovalRepository
    {
        public async Task<Approval> AddAsync(Approval approval)
        {
            await dbContext.Approvals.AddAsync(approval);
            await dbContext.SaveChangesAsync();
            return approval;
        }

        public async Task<IEnumerable<Approval>> GetByFileIdAsync(int fileId)
        {
            return await dbContext.Approvals
                .Where(a => a.FileFieldId == fileId)
                .ToListAsync();
        }
    }
}
