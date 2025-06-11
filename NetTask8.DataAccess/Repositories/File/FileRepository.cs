using NetTask8.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.DataAccess.Repositories.File
{
    public class FileRepository : IFileRepository
    {
        public Task<FileField> AddAsync(FileField file)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FileField>> GetFilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FileField> GetWithApprovalsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
