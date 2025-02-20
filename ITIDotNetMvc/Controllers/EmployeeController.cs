using ITIDotNetMvc.Models.Data;
using ITIDotNetMvc.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIDotNetMvc.Controllers;

public class EmployeeController : Controller
{
    AppDbContext dbContext = new AppDbContext(); 
    public IActionResult Index()
    {
        var employeeList = dbContext.Employees
            .Include(d => d.Department).ToList();

        return View("Index", employeeList);
    }

    public IActionResult Details(int id)
    {
        // 3 info not related to Model
        string msg = "Hello From Action";
        int temp = 50;
        List<string> branches = new List<string>
        {
            "Assuit",
            "Alex",
            "Cairo"
        };

        // using viewdata to send this info to view 
        ViewData["Msg"] = msg;
        ViewData["Temp"] = temp;
        ViewData["Brch"] = branches;
        // ViewData.Model = employeeModel; we can send model here

        Employee employeeModel = dbContext.Employees
            .FirstOrDefault(e => e.Id == id)!;

        return View("Details", employeeModel);
    }
}
