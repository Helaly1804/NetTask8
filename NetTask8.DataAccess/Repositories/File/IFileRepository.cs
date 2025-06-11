using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTask8.DataAccess.Models;

namespace NetTask8.DataAccess.Repositories.File
{
    public interface IFileRepository
    {
        Task<FileField> AddAsync(FileField file);
        Task<FileField> GetWithApprovalsAsync(int id);
        Task<IEnumerable<FileField>> GetFilesAsync();
        Task SaveChangesAsync();
    }
}
