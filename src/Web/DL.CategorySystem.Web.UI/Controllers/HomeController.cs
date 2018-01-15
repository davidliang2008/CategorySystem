using Microsoft.AspNetCore.Mvc;

namespace DL.CategorySystem.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}