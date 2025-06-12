using Microsoft.AspNetCore.Mvc;
using NetTask8.BusinessLogic.Services;
using NetTask8.BusinessLogic.DataTransferObjects.Approval;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NetTask8.Presentation.Controllers
{
    public class ApprovalController : Controller
    {
        private readonly IApprovalService _approvalService;

        public ApprovalController(IApprovalService approvalService)
        {
            _approvalService = approvalService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int fileId)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Employee2" && role != "Employee3")
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.FileId = fileId;
            var approvals = await _approvalService.GetApprovalsByFileIdAsync(fileId);
            return View(approvals);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int fileId, int employeeId, int decisionValue)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Employee2" && role != "Employee3")
            {
                return RedirectToAction("Login", "Auth");
            }

            var dto = new ApprovalDto
            {
                EmployeeId = employeeId,
                DecisionValue = decisionValue,
                CreatedAt = DateTime.Now
            };

            await _approvalService.AddApprovalAsync(fileId, dto);
            return RedirectToAction("Index", new { fileId });
        }

    }

}
