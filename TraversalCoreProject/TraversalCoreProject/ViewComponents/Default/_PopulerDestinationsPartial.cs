using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
	public class _PopulerDestinationsPartial : ViewComponent
	{
		DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
		public IViewComponentResult Invoke()
		{
			var values = destinationManager.TGetList();
			return View(values);
		}
	}
}

