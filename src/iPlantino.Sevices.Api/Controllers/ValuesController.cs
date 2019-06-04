using Microsoft.AspNetCore.Mvc;

namespace iPlantino.Services.API.Controllers
{
    public class ValuesController : Controller
    {
        public static int value = 0;

        public ValuesController()
        {
            value = 1;
        }

        public IActionResult Index()
        {
            return Ok(value);
        }

        public IActionResult Add()
        {
            ++value;
            return Ok(value);
        }
    }
}