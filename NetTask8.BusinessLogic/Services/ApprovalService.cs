using AutoMapper;
using NetTask8.BusinessLogic.DataTransferObjects.Approval;
using NetTask8.DataAccess.Models;
using NetTask8.DataAccess.Models.Enums;
using NetTask8.DataAccess.Repositories.Approvals;
using NetTask8.DataAccess.Repositories.Employees;
using NetTask8.DataAccess.Repositories.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.BusinessLogic.Services
{
    public class ApprovalService(IApprovalRepository _approvalRepository, IFileRepository _fileRepository, IMapper _mapper,IEmployeeRepository _employeeRepository)
    : IApprovalService
    {
        public async Task<ApprovalDto> AddApprovalAsync(int fileId, ApprovalDto dto)
        {
            var existing = await _approvalRepository.GetByFileIdAsync(fileId);
            if (existing.Any(a => a.EmployeeId == dto.EmployeeId))
                throw new InvalidOperationException("This employee has already approved this file.");
            var approval = _mapper.Map<Approval>(dto);
            approval.FileFieldId = fileId;
            approval.CreatedAt = DateTime.Now;

            // Check if same employee already approved
            var existingApprovals = await _approvalRepository.GetByFileIdAsync(fileId);
            if (existingApprovals.Any(a => a.EmployeeId == dto.EmployeeId))
                throw new InvalidOperationException("This employee has already approved.");

            // Save approval
            var saved = await _approvalRepository.AddAsync(approval);

            // Check if both Employee2 and Employee3 have approved
            var employee2Approved = existingApprovals.Any(a => a.Employee.Role == EmployeeRole.Employee2);
            var employee3Approved = existingApprovals.Any(a => a.Employee.Role == EmployeeRole.Employee3);

            var currentEmployee = await _employeeRepository.GetByIdAsync(dto.EmployeeId);
            if (currentEmployee.Role == EmployeeRole.Employee2) employee2Approved = true;
            if (currentEmployee.Role == EmployeeRole.Employee3) employee3Approved = true;

            if (employee2Approved && employee3Approved)
            {
                await _fileRepository.UpdateStatusAsync(fileId, FileStatus.Approved); // Assuming FileStatus is enum
            }

            return _mapper.Map<ApprovalDto>(saved);
        }


        public async Task<IEnumerable<ApprovalDto>> GetApprovalsByFileIdAsync(int fileId)
        {
            var approvals = await _approvalRepository.GetByFileIdAsync(fileId);
            return approvals.Select(_mapper.Map<ApprovalDto>);
        }
    }
}
