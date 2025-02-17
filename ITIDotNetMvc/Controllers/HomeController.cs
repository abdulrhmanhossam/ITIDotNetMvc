using System.Diagnostics;
using ITIDotNetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITIDotNetMvc.Controllers
{
    public class HomeController : Controller
    {

        // Method must be Public
        // ban not be static
        // can not be overloaded

        // Home/ShowView
        public ContentResult ShowMessage()
        {
            // 1. declare
            ContentResult result = new ContentResult();
            // 2. initial
            result.Content = "Hello World";
            // 3. return
            return result;
        }

        // Home/ShowView
        public ViewResult ShowView()
        {
            // 1. declare
            ViewResult result = new ViewResult();
            // 2. initial
            result.ViewName = "View1";
            // 3. return
            return result;
        }

        // Home/ShowMix?id=1&name=Ahmed
        public IActionResult ShowMix(int id, string Name)
        {
            if (id % 2 == 0)
            {
                //ViewResult result = new ViewResult();

                //result.ViewName = "View1";
                
                return View("View1");
            }
            else
            {
                //ContentResult result = new ContentResult();

                //result.Content = "Hello World From Content";
                
                return Content("Hello World From Content");
            }
        }


        #region What Action can return
        // String  --> ContentResult
        // View --> ViewResult
        // Json --> JsonResult
        // File --> FileResult
        // NotFound 404 --> NotFoundResult
        // UnAuth and more .......
        #endregion

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
