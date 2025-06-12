using NetTask8.BusinessLogic.DataTransferObjects.Approval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.BusinessLogic.Services
{
    public interface IApprovalService
    {
        Task<ApprovalDto> AddApprovalAsync(int fileId, ApprovalDto dto);
        Task<IEnumerable<ApprovalDto>> GetApprovalsByFileIdAsync(int fileId);
    }
}
