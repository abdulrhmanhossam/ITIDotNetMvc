using ITIDotNetMvc.Models.Data;
using ITIDotNetMvc.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIDotNetMvc.Controllers;

public class DepartmentController : Controller
{
    AppDbContext dbContext = new AppDbContext(); 
    public IActionResult Index()
    {
        List<Department> departmentList = dbContext
            .Departments.Include(e => e.Employees).ToList();

        return View("Index", departmentList); // Model ==> List<Department>
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View("Add");
    }

    [HttpPost] // fillter to validate data 
    public IActionResult SaveAdd(Department department)
    {
        if (department.Name is not null)
        {
            dbContext.Departments.Add(department);
            dbContext.SaveChanges();
            // calling action from anthoer action
            return RedirectToAction("Index");
        }
        return View("Add", department);
    }
}
