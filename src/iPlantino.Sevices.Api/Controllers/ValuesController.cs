using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iPlantino.Services.Api.Controllers;

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