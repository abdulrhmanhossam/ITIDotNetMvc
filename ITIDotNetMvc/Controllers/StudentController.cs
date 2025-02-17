using ITIDotNetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIDotNetMvc.Controllers;

public class StudentController : Controller
{
    public IActionResult ShowAll()
    {
        StudentBL studentBL = new StudentBL();
        List<Student> studentListModel = studentBL.GetAll();

        return View("ShowAll", studentListModel);
    }

    public IActionResult Details(int id)
    {
        StudentBL studentBL = new StudentBL();
        Student studentListModel = studentBL.GetById(id);

        return View("ShowDetails", studentListModel);
    } 
}
