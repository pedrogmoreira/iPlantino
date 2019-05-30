using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iPlantino.Services.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        [HttpGet, AllowAnonymous, Route("/")]
        public IActionResult Index()
        {
            return new RedirectResult("swagger");
        }
    }
}