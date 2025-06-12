using NetTask8.BusinessLogic.DataTransferObjects.File;
using NetTask8.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.BusinessLogic.Services
{
    public interface IFileService
    {
        Task<FileField> CreateFileAsync(CreatedFileDto dto);
        Task<IEnumerable<DetailedFileDto>> GetAllFilesAsync();
        Task<DetailedFileDto?> GetFileByIdAsync(int id);
        Task<DetailedFileDto?> GetFileWithApprovalsAsync(int id);
    }
}



