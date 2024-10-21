using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.idValue = id;
            var values = destinationManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult DestinationDetails(DestinationController d)
        {
            return View();
        }

    }
}

