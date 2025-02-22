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

    public IActionResult Add()
    {
        return View("Add");
    }

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
