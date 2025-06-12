using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTask8.DataAccess.Models;
using NetTask8.DataAccess.Models.Enums;

namespace NetTask8.DataAccess.Repositories.File
{
    public interface IFileRepository
    {
        Task<FileField> AddAsync(FileField file);
        Task<List<Approval>> GetApprovalsByFileIdAsync(int id);
        Task<IEnumerable<FileField>> GetFilesAsync();
        Task<FileField?> GetByIdAsync(int id);
        Task SaveChangesAsync();
        Task UpdateStatusAsync(int fileId, FileStatus newStatus);
    }
}
