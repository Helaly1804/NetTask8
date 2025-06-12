using Microsoft.EntityFrameworkCore;
using NetTask8.DataAccess.Data.Context;
using NetTask8.DataAccess.Models;
using NetTask8.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.DataAccess.Repositories.File
{
    public class FileRepository(ApplicationDbContext dbContext) : IFileRepository
    {
        public async Task<FileField> AddAsync(FileField file)
        {
            await dbContext.Files.AddAsync(file);
            await dbContext.SaveChangesAsync();
            return file;
        }

        public async Task<IEnumerable<FileField>> GetFilesAsync()
        {
            return await dbContext.Files.ToListAsync();
        }
        public async Task<FileField?> GetByIdAsync(int id)
        {
            return await dbContext.Files.FindAsync(id);
        }
        public async Task<List<Approval>> GetApprovalsByFileIdAsync(int id)
        {
            return await dbContext.Approvals
                .Where(a => a.FileFieldId == id)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
        public async Task UpdateStatusAsync(int fileId, FileStatus newStatus)
        {
            var file = await dbContext.Files.FindAsync(fileId);
            if (file != null)
            {
                file.Status = newStatus;
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
