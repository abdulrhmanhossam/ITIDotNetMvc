using ITIDotNetMvc.Models.Data;
using ITIDotNetMvc.Models.Entites;
using ITIDotNetMvc.ViewModel;
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

    #region ViewData and ViewBag
    //public IActionResult Details(int id)
    //{
    //    // 3 info not related to Model
    //    string msg = "Hello From Action";
    //    int temp = 50;
    //    List<string> branches = new List<string>
    //    {
    //        "Assuit",
    //        "Alex",
    //        "Cairo"
    //    };

    //    // using viewdata to send this info to view 
    //    ViewData["Msg"] = msg;
    //    ViewData["Temp"] = temp;
    //    ViewData["Brch"] = branches;
    //    // ViewData.Model = employeeModel; we can send model here

    //    Employee employeeModel = dbContext.Employees
    //        .FirstOrDefault(e => e.Id == id)!;

    //    return View("Details", employeeModel);
    //} 
    #endregion


    // using view model
    public IActionResult Details(int id)
    {
        var employee = dbContext.Employees
            .Include(d => d.Department)
            .FirstOrDefault(e => e.Id == id);

        List<string> Branches = new List<string>
        {
            "Assuit",
            "Alex",
            "Cairo"
        };
        // declare view model and map prop
        var employeeDepartmentViewModel = new EmployeeDepartmentViewModel
        {
            EmployeeName = employee!.Name,
            DepartmentName = employee.Department.Name,
            Branches = Branches,
            Color = "Red",
            Msg = "Hello From View Model",
            Temp = 12
        };

        return View(employeeDepartmentViewModel);
    }

    public IActionResult Edit(int id)
    {
        Employee employee = dbContext.Employees
            .Find(id)!;
        if (employee is null)
            return NotFound();
        return View("Edit",employee);
    }
    [HttpPost]
    public IActionResult SaveEdit(Employee employeeRequest)
    {
        if (employeeRequest.Name is not null)
        {
            Employee employee = dbContext.Employees
                .Find(employeeRequest.Id)!;

            employee.Name = employeeRequest.Name;
            employee.Salary = employeeRequest.Salary;
            employee.Address = employeeRequest.Address;
            employee.JobTitle = employeeRequest.JobTitle;
            employee.ImageUrl = employeeRequest.ImageUrl;
            employee.DepartmentId = employeeRequest.DepartmentId;

            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        return View("Edit", employeeRequest);

    }
}
