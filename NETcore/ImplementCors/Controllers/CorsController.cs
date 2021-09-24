using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementCors.Controllers
{
    public class CorsController : Controller
    {
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
