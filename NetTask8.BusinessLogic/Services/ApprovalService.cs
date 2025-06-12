using AutoMapper;
using NetTask8.BusinessLogic.DataTransferObjects.Approval;
using NetTask8.DataAccess.Models;
using NetTask8.DataAccess.Models.Enums;
using NetTask8.DataAccess.Repositories.Approvals;
using NetTask8.DataAccess.Repositories.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.BusinessLogic.Services
{
    public class ApprovalService (IApprovalRepository _approvalRepository,IMapper _mapper, IFileRepository _fileRepository) : IApprovalService
    {
        public async Task<ApprovalDto> AddApprovalAsync(int fileId, ApprovalDto dto)
        {
            var existingApprovals = await _approvalRepository.GetByFileIdAsync(fileId);

            if (existingApprovals.Any(a => a.ApproverName == dto.ApproverName))
            {
                throw new InvalidOperationException("هذا الموظف اعتمد الملف بالفعل.");
            }

            var approval = _mapper.Map<Approval>(dto);
            approval.FileFieldId = fileId;

            var saved = await _approvalRepository.AddAsync(approval);

            await UpdateFileStatusAsync(fileId);

            return _mapper.Map<ApprovalDto>(saved);
        }

        public async Task<IEnumerable<ApprovalDto>> GetApprovalsByFileIdAsync(int fileId)
        {
            var approvals = await _approvalRepository.GetByFileIdAsync(fileId);
            return approvals.Select(_mapper.Map<ApprovalDto>);
        }
        private async Task UpdateFileStatusAsync(int fileId)
        {
            var approvals = await _approvalRepository.GetByFileIdAsync(fileId);
            var relevantApprovals = approvals.Where(a => a.DecisionValue == 0 || a.DecisionValue == 1).ToList();

            // عدد موظفين مختلفين
            var distinctApprovers = relevantApprovals.Select(a => a.ApproverName).Distinct().Count();

            // شرط الرفض أولًا
            if (relevantApprovals.Any(a => a.DecisionValue == 0))
            {
                await _fileRepository.UpdateStatusAsync(fileId, FileStatus.Rejected);
                return;
            }

            // شرط الموافقة من 2 موظفين
            if (relevantApprovals.Count(a => a.DecisionValue == 1) >= 2 && distinctApprovers >= 2)
            {
                await _fileRepository.UpdateStatusAsync(fileId, FileStatus.Approved);
            }
        }
    }
}
