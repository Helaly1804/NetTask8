using AutoMapper;
using NetTask8.BusinessLogic.DataTransferObjects.File;
using NetTask8.DataAccess.Models;
using NetTask8.DataAccess.Repositories.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.BusinessLogic.Services
{
    public class FileService(IMapper mapper,IFileRepository file) : IFileService
    {
        public async Task<FileField> CreateFileAsync(CreatedFileDto dto)
        {
            return await file.AddAsync(mapper.Map<FileField>(dto));
        }

        public async Task<IEnumerable<DetailedFileDto?>> GetAllFilesAsync()
        {
            var files = await file.GetFilesAsync();
            return mapper.Map<IEnumerable<DetailedFileDto>>(files);
        }

        public async Task<DetailedFileDto?> GetFileByIdAsync(int id)
        {
            var fil = file.GetByIdAsync(id);    
            return mapper.Map<DetailedFileDto>(fil);
        }

        public async Task<DetailedFileDto?> GetFileWithApprovalsAsync(int id)
        {
            var fil = file.GetApprovalsByFileIdAsync(id);
            return mapper.Map<DetailedFileDto>(fil);
        }
    }
}
