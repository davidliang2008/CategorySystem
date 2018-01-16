using Microsoft.AspNetCore.Mvc;

namespace DL.CategorySystem.Web.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}