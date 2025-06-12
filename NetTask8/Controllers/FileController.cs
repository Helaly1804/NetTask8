using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetTask8.BusinessLogic.DataTransferObjects.File;
using NetTask8.BusinessLogic.Services;

namespace NetTask8.Presentation.Controllers
{
    public class FileController(IFileService _fileService, IApprovalService _approvalService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var files = await _fileService.GetAllFilesAsync();
            return View(files);
        }

        public IActionResult Create()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Employee1")
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatedFileDto dto)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Employee1")
            {
                return RedirectToAction("Login", "Auth");
            }
            if (!ModelState.IsValid) return View(dto);

            await _fileService.CreateFileAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var file = await _fileService.GetFileByIdAsync(id); // على حسب اسمك في السيرفيس
            if (file == null)
                return NotFound();

            var approvals = await _approvalService.GetApprovalsByFileIdAsync(id);
            ViewBag.Approvals = approvals;

            return View(file);
        }
    }
}
