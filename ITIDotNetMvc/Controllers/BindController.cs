using ITIDotNetMvc.Models.Entites;
using Microsoft.AspNetCore.Mvc;

namespace ITIDotNetMvc.Controllers
{
    public class BindController : Controller
    {
        // Binding Premitive (int, string ....)
        // Bind/TestPremitive?name=ahmed&age=12
        // Bind/TestPremitive/10?name=ahmed&age=12
        // Bind/TestPremitive?color[1]=red&color[0]=blue i can select index at URL
        public IActionResult TestPremitive
            (string name, string[] color, int age, int id)
        {
            return Content($"{name} \t {age}");
        }

        // Binding Collections
        // Bind/TestDictionary?phones[Ahmed]=1234&phones[ziad]=5765
        public IActionResult TestDictionary(Dictionary<string, string> phones)
        {
            return Content("Ok");
        }

        // Binding Object
        // calling prop inside object
        // Bind/TestObject?id=10&name=SD&managername=Hossam&Employees[0].Name="Ziad"
        public IActionResult TestObject(Department department)
        {
            return Content("Object");
        }
    }
}
