using Microsoft.AspNetCore.Mvc;
using NetTask8.BusinessLogic.Services;
using NetTask8.Presentation.ViewModels;

public class AuthController : Controller
{
    private readonly IEmployeeService _employeeService;

    public AuthController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var employee = await _employeeService.ValidateLoginAsync(model.Username, model.Password);
        if (employee == null)
        {
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        // Store session or cookie
        HttpContext.Session.SetInt32("EmployeeId", employee.Id);
        HttpContext.Session.SetString("Role", employee.Role.ToString());

        return RedirectToAction("Index", "File"); // or Approval
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}

