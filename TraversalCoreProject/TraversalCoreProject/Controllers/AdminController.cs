using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace TraversalCoreProject.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult AppBrandDemoPartial()
        {
            return PartialView();
        }
    }
}

