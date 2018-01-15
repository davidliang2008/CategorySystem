using DL.CategorySystem.Reporting.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DL.CategorySystem.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _mediator.Send(new GetCategories());
            return View(categories);
        }
    }
}