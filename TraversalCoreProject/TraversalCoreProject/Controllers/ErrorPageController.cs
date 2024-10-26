using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace TraversalCoreProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {

            return View();
        }
    }
}

